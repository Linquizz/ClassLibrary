using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // Конструктор 1 CSquareMatrix(int n)

        [TestMethod]
        public void Constructor1_NormalSize_SizeEquals4()
        {
            int n = 4;
            int expected = 4;

            CSquareMatrix matrix = new CSquareMatrix(n);
            int actual = matrix.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor1_MinSize_SizeEquals2()
        {
            int n = 2;
            int expected = 2;

            CSquareMatrix matrix = new CSquareMatrix(n);
            int actual = matrix.Size;

            Assert.AreEqual(expected, actual);
        }

        // Конструктор 2 CSquareMatrix(double[,])

        [TestMethod]
        public void Constructor2_Matrix2x2_DataCopiedCorrectly()
        {
            double[,] src = { { 1, 2 }, { 3, 4 } };
            double expected = 4;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix[1, 1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor2_Matrix3x3_SizeEquals3()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int expected = 3;

            CSquareMatrix matrix = new CSquareMatrix(src);
            int actual = matrix.Size;

            Assert.AreEqual(expected, actual);
        }

        // Индексатор

        [TestMethod]
        public void Indexer_SetAndGet_ReturnsCorrectValue()
        {
            CSquareMatrix matrix = new CSquareMatrix(3);
            double expected = 7.5;

            matrix[1, 2] = 7.5;
            double actual = matrix[1, 2];

            Assert.AreEqual(expected, actual);
        }

        // DiagonalProduct без параметров (сумма всех)

        [TestMethod]
        public void DiagonalProduct_NoParams_AllPositive_Returns45()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expected = 45;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct()[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_NoParams_WithNegative_Returns2()
        {
            double[,] src = { { -1, 2 }, { -3, 4 } };
            double expected = 2;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct()[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_NoParams_AllZero_Returns0()
        {
            double expected = 0;

            CSquareMatrix matrix = new CSquareMatrix(3);
            double actual = matrix.DiagonalProduct()[0];

            Assert.AreEqual(expected, actual);
        }

        // DiagonalProduct главная диагональ (параметр 0)

        [TestMethod]
        public void DiagonalProduct_MainDiag_Returns30()
        {
            double[,] src = { { 2, 0, 0 }, { 0, 3, 0 }, { 0, 0, 5 } };
            double expected = 30;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0)[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_MainDiagWithZero_Returns0()
        {
            double[,] src = { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 4 } };
            double expected = 0;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0)[0];

            Assert.AreEqual(expected, actual);
        }

        // DiagonalProduct диагонали выше главной (+1, +2)

        [TestMethod]
        public void DiagonalProduct_Above1_Returns168()
        {
            double[,] src = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            double expected = 168;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(1)[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_Above2_Returns24()
        {
            double[,] src = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            double expected = 24;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(2)[0];

            Assert.AreEqual(expected, actual);
        }

        // DiagonalProduct диагонали ниже главной (-1, -2)

        [TestMethod]
        public void DiagonalProduct_Below1_Returns750()
        {
            double[,] src = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            double expected = 750;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(-1)[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_Below2_Returns126()
        {
            double[,] src = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            double expected = 126;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(-2)[0];

            Assert.AreEqual(expected, actual);
        }

        // DiagonalProduct несколько диагоналей одновременно

        [TestMethod]
        public void DiagonalProduct_Multiple_MainDiagReturns45()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expected = 45;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0, 1, -1)[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_Multiple_Above1Returns12()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expected = 12;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0, 1, -1)[1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_Multiple_Below1Returns32()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expected = 32;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0, 1, -1)[2];

            Assert.AreEqual(expected, actual);
        }

        // Граничные тесты

        [TestMethod]
        public void DiagonalProduct_OutOfRange_Returns0()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expected = 0;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(3)[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiagonalProduct_MinMatrix2x2_Returns15()
        {
            double[,] src = { { 3, 7 }, { 2, 5 } };
            double expected = 15;

            CSquareMatrix matrix = new CSquareMatrix(src);
            double actual = matrix.DiagonalProduct(0)[0];

            Assert.AreEqual(expected, actual);
        }
    }
}