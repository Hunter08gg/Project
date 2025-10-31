namespace PersonalFinanceTracker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            dateTimePicker = new DateTimePicker();
            comboBoxCategory = new ComboBox();
            label3 = new Label();
            textBoxAmount = new TextBox();
            label2 = new Label();
            comboBoxType = new ComboBox();
            label1 = new Label();
            buttonAdd = new Button();
            label4 = new Label();
            textBoxBalance = new TextBox();
            dataGridViewOperations = new DataGridView();
            buttonUpdateBalance = new Button();
            buttonDelete = new Button();
            buttonManageCategories = new Button();
            groupBox2 = new GroupBox();
            comboBoxMonth = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lblExpensesThisMonth = new Label();
            lblIncomeThisMonth = new Label();
            lblBalanceThisMonth = new Label();
            lblExpensesLastMonth = new Label();
            lblIncomeLastMonth = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker);
            groupBox1.Controls.Add(comboBoxCategory);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxAmount);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBoxType);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление операции";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(80, 92);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(120, 23);
            dateTimePicker.TabIndex = 7;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(80, 57);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 23);
            comboBoxCategory.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 60);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Категория:";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(220, 22);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(100, 23);
            textBoxAmount.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 25);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 3;
            label2.Text = "Сумма:";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(60, 22);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(100, 23);
            comboBoxType.TabIndex = 2;
            comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Тип:";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(220, 90);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 30);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(400, 30);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 1;
            label4.Text = "Общий баланс:";
            // 
            // textBoxBalance
            // 
            textBoxBalance.Location = new Point(500, 27);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.ReadOnly = true;
            textBoxBalance.Size = new Size(100, 23);
            textBoxBalance.TabIndex = 2;
            textBoxBalance.Text = "0";
            // 
            // dataGridViewOperations
            // 
            dataGridViewOperations.AllowUserToAddRows = false;
            dataGridViewOperations.AllowUserToDeleteRows = false;
            dataGridViewOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOperations.Location = new Point(12, 180);
            dataGridViewOperations.Name = "dataGridViewOperations";
            dataGridViewOperations.ReadOnly = true;
            dataGridViewOperations.Size = new Size(600, 200);
            dataGridViewOperations.TabIndex = 3;
            // 
            // buttonUpdateBalance
            // 
            buttonUpdateBalance.Location = new Point(400, 60);
            buttonUpdateBalance.Name = "buttonUpdateBalance";
            buttonUpdateBalance.Size = new Size(120, 30);
            buttonUpdateBalance.TabIndex = 4;
            buttonUpdateBalance.Text = "Обновить баланс";
            buttonUpdateBalance.UseVisualStyleBackColor = true;
            buttonUpdateBalance.Click += buttonUpdateBalance_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(400, 100);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(120, 30);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить запись";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonManageCategories
            // 
            buttonManageCategories.Location = new Point(400, 140);
            buttonManageCategories.Name = "buttonManageCategories";
            buttonManageCategories.Size = new Size(120, 30);
            buttonManageCategories.TabIndex = 6;
            buttonManageCategories.Text = "Категории";
            buttonManageCategories.UseVisualStyleBackColor = true;
            buttonManageCategories.Click += buttonManageCategories_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxMonth);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(lblExpensesThisMonth);
            groupBox2.Controls.Add(lblIncomeThisMonth);
            groupBox2.Controls.Add(lblBalanceThisMonth);
            groupBox2.Controls.Add(lblExpensesLastMonth);
            groupBox2.Controls.Add(lblIncomeLastMonth);
            groupBox2.Location = new Point(12, 390);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(600, 120);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Статистика по месяцам";
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(80, 85);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(150, 23);
            comboBoxMonth.TabIndex = 11;
            comboBoxMonth.SelectedIndexChanged += comboBoxMonth_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 88);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 10;
            label10.Text = "Месяц:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(480, 60);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 9;
            label9.Text = "Прошлый:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(480, 30);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 8;
            label8.Text = "Текущий:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(320, 60);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 7;
            label7.Text = "Прошлый:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(320, 30);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 6;
            label6.Text = "Текущий:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 30);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 5;
            label5.Text = "Текущий:";
            // 
            // lblExpensesThisMonth
            // 
            lblExpensesThisMonth.AutoSize = true;
            lblExpensesThisMonth.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblExpensesThisMonth.ForeColor = Color.Red;
            lblExpensesThisMonth.Location = new Point(400, 30);
            lblExpensesThisMonth.Name = "lblExpensesThisMonth";
            lblExpensesThisMonth.Size = new Size(24, 15);
            lblExpensesThisMonth.TabIndex = 4;
            lblExpensesThisMonth.Text = "0 ₽";
            // 
            // lblIncomeThisMonth
            // 
            lblIncomeThisMonth.AutoSize = true;
            lblIncomeThisMonth.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblIncomeThisMonth.ForeColor = Color.Green;
            lblIncomeThisMonth.Location = new Point(240, 30);
            lblIncomeThisMonth.Name = "lblIncomeThisMonth";
            lblIncomeThisMonth.Size = new Size(24, 15);
            lblIncomeThisMonth.TabIndex = 3;
            lblIncomeThisMonth.Text = "0 ₽";
            // 
            // lblBalanceThisMonth
            // 
            lblBalanceThisMonth.AutoSize = true;
            lblBalanceThisMonth.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBalanceThisMonth.Location = new Point(80, 30);
            lblBalanceThisMonth.Name = "lblBalanceThisMonth";
            lblBalanceThisMonth.Size = new Size(24, 15);
            lblBalanceThisMonth.TabIndex = 2;
            lblBalanceThisMonth.Text = "0 ₽";
            // 
            // lblExpensesLastMonth
            // 
            lblExpensesLastMonth.AutoSize = true;
            lblExpensesLastMonth.ForeColor = Color.Red;
            lblExpensesLastMonth.Location = new Point(400, 60);
            lblExpensesLastMonth.Name = "lblExpensesLastMonth";
            lblExpensesLastMonth.Size = new Size(22, 15);
            lblExpensesLastMonth.TabIndex = 1;
            lblExpensesLastMonth.Text = "0 ₽";
            // 
            // lblIncomeLastMonth
            // 
            lblIncomeLastMonth.AutoSize = true;
            lblIncomeLastMonth.ForeColor = Color.Green;
            lblIncomeLastMonth.Location = new Point(240, 60);
            lblIncomeLastMonth.Name = "lblIncomeLastMonth";
            lblIncomeLastMonth.Size = new Size(22, 15);
            lblIncomeLastMonth.TabIndex = 0;
            lblIncomeLastMonth.Text = "0 ₽";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 522);
            Controls.Add(groupBox2);
            Controls.Add(buttonManageCategories);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdateBalance);
            Controls.Add(dataGridViewOperations);
            Controls.Add(textBoxBalance);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "0";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBoxCategory;
        private Label label3;
        private TextBox textBoxAmount;
        private Label label2;
        private ComboBox comboBoxType;
        private Label label1;
        private Button buttonAdd;
        private Label label4;
        private TextBox textBoxBalance;
        private DataGridView dataGridViewOperations;
        private Button buttonUpdateBalance;
        private Button buttonDelete;
        private Button buttonManageCategories;
        private GroupBox groupBox2;
        private Label lblExpensesThisMonth;
        private Label lblIncomeThisMonth;
        private Label lblBalanceThisMonth;
        private Label lblExpensesLastMonth;
        private Label lblIncomeLastMonth;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxMonth;
        private Label label10;
    }
}