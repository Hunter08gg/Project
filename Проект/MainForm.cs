using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Проект
{
    public partial class MainForm : Form
    {
        private BindingList<FinancialOperation> operations;
        private int nextId = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            operations = new BindingList<FinancialOperation>();
            comboBoxType.Items.Add("Доход");
            comboBoxType.Items.Add("Расход");
            comboBoxType.SelectedIndex = 0;
            dataGridViewOperations.DataSource = operations;
            dataGridViewOperations.AutoGenerateColumns = false;
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Date", HeaderText = "Дата" });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Тип" });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Сумма" });
            dataGridViewOperations.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Category", HeaderText = "Категория" });
            dateTimePicker.Value = DateTime.Today;
            UpdateBalance();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxAmount.Text, out decimal amount) && amount > 0)
            {
                var newOperation = new FinancialOperation(nextId++, comboBoxType.SelectedItem.ToString(), amount, textBoxCategory.Text, dateTimePicker.Value);
                operations.Add(newOperation);
                textBoxAmount.Clear();
                textBoxCategory.Clear();
                UpdateBalance();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму.");
            }
        }

        private void UpdateBalance()
        {
            decimal balance = 0;
            foreach (var op in operations)
            {
                if (op.Type == "Доход") balance += op.Amount;
                else if (op.Type == "Расход") balance -= op.Amount;
            }
            textBoxBalance.Text = balance.ToString("C2");
        }

        private void buttonUpdateBalance_Click(object sender, EventArgs e)
        {
            UpdateBalance();
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
            Id = id; Type = type; Amount = amount; Category = category; Date = date;
        }

        public FinancialOperation() { }
    }
}