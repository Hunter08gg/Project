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
    public partial class MainForm : Form
    {
        private BindingList<FinancialOperation> operations;
        private List<string> categories;
        private string connectionString = "Data Source=finance.db";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            LoadCategories();
            LoadOperations();

            comboBoxType.Items.Add("Доход");
            comboBoxType.Items.Add("Расход");
            comboBoxType.SelectedIndex = 0;

            ConfigureDataGridView();
            UpdateBalance();
            UpdateCategoriesComboBox();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Таблица операций
                var command1 = connection.CreateCommand();
                command1.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Operations (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Type TEXT NOT NULL,
                        Amount DECIMAL NOT NULL,
                        Category TEXT NOT NULL,
                        Date TEXT NOT NULL
                    )";
                command1.ExecuteNonQuery();

                // Таблица категорий (простая)
                var command2 = connection.CreateCommand();
                command2.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    )";
                command2.ExecuteNonQuery();

                // Добавляем базовые категории, если их нет
                InitializeDefaultCategories();
            }
        }

        private void InitializeDefaultCategories()
        {
            var defaultCategories = new List<string>
            {
                "Зарплата", "Премия", "Инвестиции", "Подарки",
                "Продукты", "Транспорт", "Жилье", "Развлечения",
                "Здоровье", "Одежда", "Образование", "Прочее"
            };

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var category in defaultCategories)
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT OR IGNORE INTO Categories (Name) VALUES (@name)";
                    command.Parameters.AddWithValue("@name", category);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadCategories()
        {
            categories = new List<string>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM Categories ORDER BY Name";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void UpdateCategoriesComboBox()
        {
            comboBoxCategory.Items.Clear();

            foreach (var category in categories)
            {
                comboBoxCategory.Items.Add(category);
            }

            if (comboBoxCategory.Items.Count > 0)
            {
                comboBoxCategory.SelectedIndex = 0;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Для простоты показываем все категории для обоих типов
        }

        private void LoadOperations()
        {
            operations = new BindingList<FinancialOperation>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Operations ORDER BY Date DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        operations.Add(new FinancialOperation(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDecimal(2),
                            reader.GetString(3),
                            DateTime.Parse(reader.GetString(4))
                        ));
                    }
                }
            }

            dataGridViewOperations.DataSource = operations;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewOperations.AutoGenerateColumns = false;
            dataGridViewOperations.Columns.Clear();

            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Date",
                HeaderText = "Дата",
                Width = 120
            });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Type",
                HeaderText = "Тип",
                Width = 80
            });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Amount",
                HeaderText = "Сумма",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                Width = 150
            });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxAmount.Text, out decimal amount) && amount > 0)
            {
                if (comboBoxCategory.SelectedItem == null)
                {
                    MessageBox.Show("Выберите категорию.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newOperation = new FinancialOperation(
                    0,
                    comboBoxType.SelectedItem.ToString(),
                    amount,
                    comboBoxCategory.SelectedItem.ToString(),
                    dateTimePicker.Value
                );

                AddOperationToDatabase(newOperation);
                LoadOperations();

                textBoxAmount.Clear();
                UpdateBalance();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму.", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddOperationToDatabase(FinancialOperation operation)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Operations (Type, Amount, Category, Date)
                    VALUES (@type, @amount, @category, @date)";

                command.Parameters.AddWithValue("@type", operation.Type);
                command.Parameters.AddWithValue("@amount", operation.Amount);
                command.Parameters.AddWithValue("@category", operation.Category);
                command.Parameters.AddWithValue("@date", operation.Date.ToString("yyyy-MM-dd"));

                command.ExecuteNonQuery();
            }
        }

        private void UpdateBalance()
        {
            decimal balance = 0;

            foreach (var op in operations)
            {
                if (op.Type == "Доход")
                {
                    balance += op.Amount;
                }
                else if (op.Type == "Расход")
                {
                    balance -= op.Amount;
                }
            }

            textBoxBalance.Text = balance.ToString("C2");
            textBoxBalance.ForeColor = balance >= 0 ? Color.Green : Color.Red;
        }

        private void buttonUpdateBalance_Click(object sender, EventArgs e)
        {
            UpdateBalance();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.CurrentRow != null)
            {
                var selectedOperation = (FinancialOperation)dataGridViewOperations.CurrentRow.DataBoundItem;

                var result = MessageBox.Show($"Удалить операцию '{selectedOperation.Category}' на сумму {selectedOperation.Amount:C2}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteOperationFromDatabase(selectedOperation.Id);
                    LoadOperations();
                    UpdateBalance();
                }
            }
            else
            {
                MessageBox.Show("Выберите операцию для удаления.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteOperationFromDatabase(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Operations WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        private void buttonManageCategories_Click(object sender, EventArgs e)
        {
            using (var form = new SimpleCategoriesForm(categories, connectionString))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                    UpdateCategoriesComboBox();
                }
            }
        }
    }

    public class FinancialOperation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public FinancialOperation(int id, string type, decimal amount, string category, DateTime date)
        {
            Id = id;
            Type = type;
            Amount = amount;
            Category = category;
            Date = date;
        }

        public FinancialOperation() { }
    }
}