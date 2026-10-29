using System;
using System.Windows.Forms;
using ClassLibrary;

namespace ClassForm
{
    public partial class Form1 : Form
    {
        private CSquareMatrix squareMatrix = null;

        public Form1()
        {
            InitializeComponent();
        }

        // «Создать матрицу»
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDownSize.Value;
            squareMatrix = new CSquareMatrix(n);
            SetupGrid(n);
            lblStatus.Text = $"Матрица {n}×{n} создана. Введите значения и нажмите «Применить».";
            grpResult.Visible = false;
        }

        // «Применить значения»
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (squareMatrix == null) { lblStatus.Text = "Сначала создайте матрицу!"; return; }
            int n = squareMatrix.Size;
            try
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        string cell = dataGridViewMatrix.Rows[i].Cells[j].Value?.ToString() ?? "0";
                        squareMatrix[i, j] = double.Parse(cell.Replace(',', '.'),
                                              System.Globalization.CultureInfo.InvariantCulture);
                    }
                lblStatus.Text = "Значения применены.";
            }
            catch { lblStatus.Text = "Ошибка: введите корректные числа в ячейки матрицы."; }
        }

        // «Вычислить»
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (squareMatrix == null) { lblStatus.Text = "Сначала создайте матрицу!"; return; }

            string input = txtDiags.Text.Trim();
            double[] results;
            string description;

            if (string.IsNullOrEmpty(input))
            {
                // Вызов без параметров - сумма всех элементов
                results = squareMatrix.DiagonalProduct();
                description = "Сумма всех элементов матрицы (без параметров):";
            }
            else
            {
                string[] parts = input.Split(new[] { ',', ';', ' ' },
                                              StringSplitOptions.RemoveEmptyEntries);
                int[] diagNums = new int[parts.Length];
                try
                {
                    for (int i = 0; i < parts.Length; i++)
                        diagNums[i] = int.Parse(parts[i].Trim());
                }
                catch { lblStatus.Text = "Ошибка: введите номера диагоналей целыми числами через запятую."; return; }

                results = squareMatrix.DiagonalProduct(diagNums);
                description = $"Произведение элементов диагоналей [{input}]:";
            }

            var sb = new System.Text.StringBuilder();
            sb.AppendLine(description);

            if (string.IsNullOrEmpty(input))
            {
                sb.AppendLine($"  Результат = {results[0]:F4}");
            }
            else
            {
                string[] parts = input.Split(new[] { ',', ';', ' ' },
                                              StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < results.Length; i++)
                {
                    int d = int.Parse(parts[i].Trim());
                    string diagName = d == 0 ? "главная"
                                   : d > 0 ? $"выше главной на {d}"
                                             : $"ниже главной на {Math.Abs(d)}";
                    sb.AppendLine($"  Диагональ {d,3} ({diagName}): произведение = {results[i]:F4}");
                }
            }

            txtResult.Text = sb.ToString();
            grpResult.Visible = true;
        }

        // «Заполнить случайно»
        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (squareMatrix == null) { lblStatus.Text = "Сначала создайте матрицу!"; return; }
            Random rnd = new Random();
            int n = squareMatrix.Size;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    double val = Math.Round(rnd.NextDouble() * 18 - 9, 1);
                    squareMatrix[i, j] = val;
                    dataGridViewMatrix.Rows[i].Cells[j].Value = val.ToString("F1");
                }
            lblStatus.Text = "Матрица заполнена случайными числами.";
        }

        // Вспомогательный метод: настройка DataGridView под размер n×n
        private void SetupGrid(int n)
        {
            dataGridViewMatrix.Rows.Clear();
            dataGridViewMatrix.Columns.Clear();
            for (int j = 0; j < n; j++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = $"[{j}]",
                    Width = 60,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dataGridViewMatrix.Columns.Add(col);
            }
            for (int i = 0; i < n; i++)
            {
                dataGridViewMatrix.Rows.Add();
                dataGridViewMatrix.Rows[i].HeaderCell.Value = $"[{i}]";
                for (int j = 0; j < n; j++)
                    dataGridViewMatrix.Rows[i].Cells[j].Value = "0";
            }
        }
    }
}
