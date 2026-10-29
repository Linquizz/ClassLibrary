using System;

namespace ClassLibrary
{
    public class CSquareMatrix
    {
        // Закрытое поле – матрица вещественных чисел
        private double[,] matrix;

        // Свойство для определения размерности матрицы
        public int Size
        {
            get { return matrix.GetLength(0); }
        }

        // Индексатор для доступа к элементам поля-массива
        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        // Конструктор 1: параметр – размерность матрицы
        public CSquareMatrix(int n)
        {
            matrix = new double[n, n];
        }

        // Конструктор 2: параметр – готовая матрица вещественных чисел
        public CSquareMatrix(double[,] matrixValue)
        {
            int n = matrixValue.GetLength(0);
            matrix = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = matrixValue[i, j];
        }

        // Метод с переменным числом параметров 
        // Правила нумерации диагоналей:
        //   0         – главная диагональ
        //   1, 2, ... – диагонали выше главной
        //  -1,-2, ... – диагонали ниже главной
        // Если параметры не переданы (params пуст): вычисляется сумма элементов всех диагоналей
        // Если переданы номера диагоналей: вычисляется произведение элементов каждой указанной диагонали, возвращается массив результатов

        public double[] DiagonalProduct(params int[] diagNumbers)
        {
            int n = Size;

            // Случай 1: параметры не переданы - сумма всех элементов
            if (diagNumbers.Length == 0)
            {
                double sum = 0;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        sum += matrix[i, j];
                return new double[] { sum };
            }

            // Случай 2: переданы конкретные номера диагоналей
            double[] results = new double[diagNumbers.Length];

            for (int d = 0; d < diagNumbers.Length; d++)
            {
                int diag = diagNumbers[d];
                double product = 1;
                bool hasElements = false;

                for (int i = 0; i < n; i++)
                {
                    int j = i + diag;   // diag > 0 - выше главной
                                        // diag < 0 - ниже главной
                    if (j >= 0 && j < n)
                    {
                        product *= matrix[i, j];
                        hasElements = true;
                    }
                }

                results[d] = hasElements ? product : 0;
            }

            return results;
        }

        // Вспомогательный метод
        public string MatrixToString()
        {
            int n = Size;
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sb.Append(string.Format("{0,8:F2}", matrix[i, j]));
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}