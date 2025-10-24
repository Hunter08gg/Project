using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace PersonalFinanceTracker
{
    public partial class CategoriesForm : Form
    {
        private List<string> categories;
        private string connectionString;
        private BindingList<string> bindingCategories;

        public CategoriesForm(List<string> existingCategories, string connectionString)
        {
            InitializeComponent();
            this.categories = existingCategories;
            this.connectionString = connectionString;
            LoadCategoriesData();
        }

        private void LoadCategoriesData()
        {
            bindingCategories = new BindingList<string>(categories);
            listBoxCategories.DataSource = bindingCategories;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newCategory = textBoxNewCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(newCategory))
            {
                MessageBox.Show("Введите название категории.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (categories.Contains(newCategory, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Категория с таким названием уже существует.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                AddCategoryToDatabase(newCategory);
                categories.Add(newCategory);
                bindingCategories.Add(newCategory);
                textBoxNewCategory.Clear();

                // Сортируем список
                var sorted = bindingCategories.OrderBy(c => c).ToList();
                bindingCategories = new BindingList<string>(sorted);
                listBoxCategories.DataSource = bindingCategories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении категории: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCategoryToDatabase(string name)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Categories (Name) VALUES (@name)";
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedItem != null)
            {
                string selectedCategory = listBoxCategories.SelectedItem.ToString();

                // Проверяем, используется ли категория в операциях
                if (IsCategoryUsed(selectedCategory))
                {
                    MessageBox.Show("Невозможно удалить категорию, так как она используется в операциях.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show($"Удалить категорию '{selectedCategory}'?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteCategoryFromDatabase(selectedCategory);
                    categories.Remove(selectedCategory);
                    bindingCategories.Remove(selectedCategory);
                }
            }
            else
            {
                MessageBox.Show("Выберите категорию для удаления.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsCategoryUsed(string categoryName)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Operations WHERE Category = @category";
                command.Parameters.AddWithValue("@category", categoryName);

                var count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void DeleteCategoryFromDatabase(string categoryName)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Categories WHERE Name = @name";
                command.Parameters.AddWithValue("@name", categoryName);
                command.ExecuteNonQuery();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxNewCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonAdd_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}