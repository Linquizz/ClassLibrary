using System.Drawing;
using System.Windows.Forms;

namespace ClassForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpMatrix;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dataGridViewMatrix;
        private System.Windows.Forms.GroupBox grpCalc;
        private System.Windows.Forms.Label lblDiagsHint;
        private System.Windows.Forms.TextBox txtDiags;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpMatrix = new GroupBox();
            lblSize = new Label();
            numericUpDownSize = new NumericUpDown();
            btnCreate = new Button();
            btnRandom = new Button();
            btnApply = new Button();
            dataGridViewMatrix = new DataGridView();
            grpCalc = new GroupBox();
            lblDiagsHint = new Label();
            txtDiags = new TextBox();
            btnCalculate = new Button();
            grpResult = new GroupBox();
            txtResult = new TextBox();
            lblStatus = new Label();
            grpMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).BeginInit();
            grpCalc.SuspendLayout();
            grpResult.SuspendLayout();
            SuspendLayout();
            // 
            // grpMatrix
            // 
            grpMatrix.Controls.Add(lblSize);
            grpMatrix.Controls.Add(numericUpDownSize);
            grpMatrix.Controls.Add(btnCreate);
            grpMatrix.Controls.Add(btnRandom);
            grpMatrix.Controls.Add(btnApply);
            grpMatrix.Controls.Add(dataGridViewMatrix);
            grpMatrix.Location = new Point(12, 12);
            grpMatrix.Name = "grpMatrix";
            grpMatrix.Size = new Size(660, 340);
            grpMatrix.TabIndex = 0;
            grpMatrix.TabStop = false;
            grpMatrix.Text = "1. Матрица";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(10, 25);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(124, 20);
            lblSize.TabIndex = 0;
            lblSize.Text = "Размерность (n):";
            // 
            // numericUpDownSize
            // 
            numericUpDownSize.Location = new Point(135, 22);
            numericUpDownSize.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownSize.Name = "numericUpDownSize";
            numericUpDownSize.Size = new Size(55, 27);
            numericUpDownSize.TabIndex = 1;
            numericUpDownSize.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(205, 20);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(130, 26);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Создать матрицу";
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnRandom
            // 
            btnRandom.Location = new Point(345, 20);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(150, 26);
            btnRandom.TabIndex = 3;
            btnRandom.Text = "Заполнить случайно";
            btnRandom.Click += btnRandom_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(505, 20);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(140, 26);
            btnApply.TabIndex = 4;
            btnApply.Text = "Применить значения";
            btnApply.Click += btnApply_Click;
            // 
            // dataGridViewMatrix
            // 
            dataGridViewMatrix.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewMatrix.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewMatrix.Location = new Point(10, 55);
            dataGridViewMatrix.Name = "dataGridViewMatrix";
            dataGridViewMatrix.RowHeadersWidth = 40;
            dataGridViewMatrix.Size = new Size(635, 270);
            dataGridViewMatrix.TabIndex = 5;
            // 
            // grpCalc
            // 
            grpCalc.Controls.Add(lblDiagsHint);
            grpCalc.Controls.Add(txtDiags);
            grpCalc.Controls.Add(btnCalculate);
            grpCalc.Location = new Point(12, 360);
            grpCalc.Name = "grpCalc";
            grpCalc.Size = new Size(660, 87);
            grpCalc.TabIndex = 1;
            grpCalc.TabStop = false;
            grpCalc.Text = "2. Вычисление произведения диагоналей";
            // 
            // lblDiagsHint
            // 
            lblDiagsHint.Location = new Point(10, 23);
            lblDiagsHint.Name = "lblDiagsHint";
            lblDiagsHint.Size = new Size(300, 62);
            lblDiagsHint.TabIndex = 0;
            lblDiagsHint.Text = "Номера диагоналей через запятую\r\n(0=главная, 1,2…=выше, -1,-2…=ниже)\r\nПусто = сумма всех элементов:";
            // 
            // txtDiags
            // 
            txtDiags.Location = new Point(315, 30);
            txtDiags.Name = "txtDiags";
            txtDiags.Size = new Size(200, 27);
            txtDiags.TabIndex = 1;
            txtDiags.Text = "0, 1, -1";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(525, 28);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 26);
            btnCalculate.TabIndex = 2;
            btnCalculate.Text = "Вычислить";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // grpResult
            // 
            grpResult.Controls.Add(txtResult);
            grpResult.Location = new Point(12, 448);
            grpResult.Name = "grpResult";
            grpResult.Size = new Size(660, 105);
            grpResult.TabIndex = 2;
            grpResult.TabStop = false;
            grpResult.Text = "3. Результат";
            grpResult.Visible = false;
            // 
            // txtResult
            // 
            txtResult.Font = new Font("Consolas", 9F);
            txtResult.Location = new Point(10, 20);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(635, 75);
            txtResult.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.DarkBlue;
            lblStatus.Location = new Point(12, 558);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(660, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Укажите размерность и нажмите «Создать матрицу».";
            // 
            // Form1
            // 
            ClientSize = new Size(682, 585);
            Controls.Add(grpMatrix);
            Controls.Add(grpCalc);
            Controls.Add(grpResult);
            Controls.Add(lblStatus);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лаб. №7 — Квадратная матрица (Вариант 6)";
            grpMatrix.ResumeLayout(false);
            grpMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).EndInit();
            grpCalc.ResumeLayout(false);
            grpCalc.PerformLayout();
            grpResult.ResumeLayout(false);
            grpResult.PerformLayout();
            ResumeLayout(false);
        }
    }
}
