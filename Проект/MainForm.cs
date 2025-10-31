using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Threading;

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
            // Устанавливаем русскую культуру для корректного отображения месяцев
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            InitializeDatabase();
            LoadCategories();
            LoadOperations();

            comboBoxType.Items.Add("Доход");
            comboBoxType.Items.Add("Расход");
            comboBoxType.SelectedIndex = 0;

            ConfigureDataGridView();
            UpdateBalance();
            UpdateCategoriesComboBox();
            InitializeMonthComboBox();
            UpdateMonthlyStatistics();
        }

        
        // Обновите метод InitializeMonthComboBox для использования русского формата
        private void InitializeMonthComboBox()
        {
            comboBoxMonth.Items.Clear();

            // Добавляем последние 12 месяцев
            var currentDate = DateTime.Now;
            for (int i = 0; i < 12; i++)
            {
                var monthDate = currentDate.AddMonths(-i);
                var monthName = monthDate.ToString("MMMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
                comboBoxMonth.Items.Add(monthName);
            }

            if (comboBoxMonth.Items.Count > 0)
            {
                comboBoxMonth.SelectedIndex = 0;
            }
        }

        private void UpdateMonthlyStatistics()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var lastMonth = currentMonth == 1 ? 12 : currentMonth - 1;
            var lastMonthYear = currentMonth == 1 ? currentYear - 1 : currentYear;

            decimal incomeThisMonth = 0;
            decimal expensesThisMonth = 0;
            decimal incomeLastMonth = 0;
            decimal expensesLastMonth = 0;

            foreach (var operation in operations)
            {
                if (operation.Date.Month == currentMonth && operation.Date.Year == currentYear)
                {
                    if (operation.Type == "Доход")
                        incomeThisMonth += operation.Amount;
                    else
                        expensesThisMonth += operation.Amount;
                }
                else if (operation.Date.Month == lastMonth && operation.Date.Year == lastMonthYear)
                {
                    if (operation.Type == "Доход")
                        incomeLastMonth += operation.Amount;
                    else
                        expensesLastMonth += operation.Amount;
                }
            }

            // Обновляем labels
            lblIncomeThisMonth.Text = incomeThisMonth.ToString("C2");
            lblExpensesThisMonth.Text = expensesThisMonth.ToString("C2");
            lblBalanceThisMonth.Text = (incomeThisMonth - expensesThisMonth).ToString("C2");

            lblIncomeLastMonth.Text = incomeLastMonth.ToString("C2");
            lblExpensesLastMonth.Text = expensesLastMonth.ToString("C2");

            // Цвета для баланса текущего месяца
            lblBalanceThisMonth.ForeColor = (incomeThisMonth - expensesThisMonth) >= 0 ? Color.Green : Color.Red;

            // Восстанавливаем стандартные подписи
            RestoreDefaultLabels();
        }

        private void UpdateSelectedMonthStatistics(string selectedMonth)
        {
            if (string.IsNullOrEmpty(selectedMonth)) return;

            try
            {
                // Парсим выбранный месяц - используем правильный формат
                var monthDate = DateTime.ParseExact(selectedMonth, "MMMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));

                decimal income = 0;
                decimal expenses = 0;

                foreach (var operation in operations)
                {
                    if (operation.Date.Month == monthDate.Month && operation.Date.Year == monthDate.Year)
                    {
                        if (operation.Type == "Доход")
                            income += operation.Amount;
                        else
                            expenses += operation.Amount;
                    }
                }

                // Обновляем labels для выбранного месяца
                lblIncomeThisMonth.Text = income.ToString("C2");
                lblExpensesThisMonth.Text = expenses.ToString("C2");
                lblBalanceThisMonth.Text = (income - expenses).ToString("C2");
                lblBalanceThisMonth.ForeColor = (income - expenses) >= 0 ? Color.Green : Color.Red;

                // Скрываем статистику за прошлый месяц при выборе конкретного месяца
                lblIncomeLastMonth.Text = "-";
                lblExpensesLastMonth.Text = "-";

                // Обновляем подписи
                label6.Text = "Выбранный:";
                label8.Text = "Выбранный:";
                label5.Text = "Выбранный:";
                label7.Visible = false;
                label9.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке месяца: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                UpdateMonthlyStatistics();
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
            UpdateMonthlyStatistics();
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
                    UpdateMonthlyStatistics();
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
            using (var form = new CategoriesForm(categories, connectionString))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                    UpdateCategoriesComboBox();
                }
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedItem != null)
            {
                var selectedMonth = comboBoxMonth.SelectedItem.ToString();
                var currentMonth = DateTime.Now.ToString("MMMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));

                if (selectedMonth == currentMonth)
                {
                    // Если выбран текущий месяц, показываем обычную статистику
                    UpdateMonthlyStatistics();
                    // Восстанавливаем labels
                    RestoreDefaultLabels();
                }
                else
                {
                    // Показываем статистику для выбранного месяца
                    UpdateSelectedMonthStatistics(selectedMonth);
                }
            }
        }
    // Новый метод для восстановления стандартных подписей
        private void RestoreDefaultLabels()
        {
            label6.Text = "Текущий:";
            label8.Text = "Текущий:";
            label5.Text = "Текущий:";
            label7.Visible = true;
            label9.Visible = true;
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