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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.dataGridViewOperations = new System.Windows.Forms.DataGridView();
            this.buttonUpdateBalance = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonManageCategories = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExpensesThisMonth = new System.Windows.Forms.Label();
            this.lblIncomeThisMonth = new System.Windows.Forms.Label();
            this.lblBalanceThisMonth = new System.Windows.Forms.Label();
            this.lblExpensesLastMonth = new System.Windows.Forms.Label();
            this.lblIncomeLastMonth = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.comboBoxCategory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление операции";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(80, 92);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker.TabIndex = 7;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(80, 57);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(200, 23);
            this.comboBoxCategory.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Категория:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(220, 22);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 23);
            this.textBoxAmount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(60, 22);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(100, 23);
            this.comboBoxType.TabIndex = 2;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(220, 90);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Общий баланс:";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(500, 27);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.ReadOnly = true;
            this.textBoxBalance.Size = new System.Drawing.Size(100, 23);
            this.textBoxBalance.TabIndex = 2;
            this.textBoxBalance.Text = "0";
            // 
            // dataGridViewOperations
            // 
            this.dataGridViewOperations.AllowUserToAddRows = false;
            this.dataGridViewOperations.AllowUserToDeleteRows = false;
            this.dataGridViewOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperations.Location = new System.Drawing.Point(12, 180);
            this.dataGridViewOperations.Name = "dataGridViewOperations";
            this.dataGridViewOperations.ReadOnly = true;
            this.dataGridViewOperations.Size = new System.Drawing.Size(600, 200);
            this.dataGridViewOperations.TabIndex = 3;
            // 
            // buttonUpdateBalance
            // 
            this.buttonUpdateBalance.Location = new System.Drawing.Point(400, 60);
            this.buttonUpdateBalance.Name = "buttonUpdateBalance";
            this.buttonUpdateBalance.Size = new System.Drawing.Size(120, 30);
            this.buttonUpdateBalance.TabIndex = 4;
            this.buttonUpdateBalance.Text = "Обновить баланс";
            this.buttonUpdateBalance.UseVisualStyleBackColor = true;
            this.buttonUpdateBalance.Click += new System.EventHandler(this.buttonUpdateBalance_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(400, 100);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 30);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить запись";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonManageCategories
            // 
            this.buttonManageCategories.Location = new System.Drawing.Point(400, 140);
            this.buttonManageCategories.Name = "buttonManageCategories";
            this.buttonManageCategories.Size = new System.Drawing.Size(120, 30);
            this.buttonManageCategories.TabIndex = 6;
            this.buttonManageCategories.Text = "Категории";
            this.buttonManageCategories.UseVisualStyleBackColor = true;
            this.buttonManageCategories.Click += new System.EventHandler(this.buttonManageCategories_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxMonth);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblExpensesThisMonth);
            this.groupBox2.Controls.Add(this.lblIncomeThisMonth);
            this.groupBox2.Controls.Add(this.lblBalanceThisMonth);
            this.groupBox2.Controls.Add(this.lblExpensesLastMonth);
            this.groupBox2.Controls.Add(this.lblIncomeLastMonth);
            this.groupBox2.Location = new System.Drawing.Point(12, 390);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 120);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Статистика по месяцам";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(480, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Прошлый:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(480, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Текущий:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Прошлый:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Текущий:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Текущий:";
            // 
            // lblExpensesThisMonth
            // 
            this.lblExpensesThisMonth.AutoSize = true;
            this.lblExpensesThisMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExpensesThisMonth.ForeColor = System.Drawing.Color.Red;
            this.lblExpensesThisMonth.Location = new System.Drawing.Point(400, 30);
            this.lblExpensesThisMonth.Name = "lblExpensesThisMonth";
            this.lblExpensesThisMonth.Size = new System.Drawing.Size(32, 15);
            this.lblExpensesThisMonth.TabIndex = 4;
            this.lblExpensesThisMonth.Text = "0 ₽";
            // 
            // lblIncomeThisMonth
            // 
            this.lblIncomeThisMonth.AutoSize = true;
            this.lblIncomeThisMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIncomeThisMonth.ForeColor = System.Drawing.Color.Green;
            this.lblIncomeThisMonth.Location = new System.Drawing.Point(240, 30);
            this.lblIncomeThisMonth.Name = "lblIncomeThisMonth";
            this.lblIncomeThisMonth.Size = new System.Drawing.Size(32, 15);
            this.lblIncomeThisMonth.TabIndex = 3;
            this.lblIncomeThisMonth.Text = "0 ₽";
            // 
            // lblBalanceThisMonth
            // 
            this.lblBalanceThisMonth.AutoSize = true;
            this.lblBalanceThisMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBalanceThisMonth.Location = new System.Drawing.Point(80, 30);
            this.lblBalanceThisMonth.Name = "lblBalanceThisMonth";
            this.lblBalanceThisMonth.Size = new System.Drawing.Size(32, 15);
            this.lblBalanceThisMonth.TabIndex = 2;
            this.lblBalanceThisMonth.Text = "0 ₽";
            // 
            // lblExpensesLastMonth
            // 
            this.lblExpensesLastMonth.AutoSize = true;
            this.lblExpensesLastMonth.ForeColor = System.Drawing.Color.Red;
            this.lblExpensesLastMonth.Location = new System.Drawing.Point(400, 60);
            this.lblExpensesLastMonth.Name = "lblExpensesLastMonth";
            this.lblExpensesLastMonth.Size = new System.Drawing.Size(32, 15);
            this.lblExpensesLastMonth.TabIndex = 1;
            this.lblExpensesLastMonth.Text = "0 ₽";
            // 
            // lblIncomeLastMonth
            // 
            this.lblIncomeLastMonth.AutoSize = true;
            this.lblIncomeLastMonth.ForeColor = System.Drawing.Color.Green;
            this.lblIncomeLastMonth.Location = new System.Drawing.Point(240, 60);
            this.lblIncomeLastMonth.Name = "lblIncomeLastMonth";
            this.lblIncomeLastMonth.Size = new System.Drawing.Size(32, 15);
            this.lblIncomeLastMonth.TabIndex = 0;
            this.lblIncomeLastMonth.Text = "0 ₽";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(80, 85);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(150, 23);
            this.comboBoxMonth.TabIndex = 11;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Месяц:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonManageCategories);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdateBalance);
            this.Controls.Add(this.dataGridViewOperations);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Учет личных финансов";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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