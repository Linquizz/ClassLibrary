using System;
using System.IO;
using ClassLibrary;

namespace TestDrivers
{
    class CTest_Driver
    {
        CSquareMatrix matrixTesting;
        StreamWriter log;
        string fileName = "logFile.dat";

        public CTest_Driver()
        {
            log = new StreamWriter(fileName, true);
            Run();
        }

        private void Run()
        {
            log.WriteLine("Тест начат: " + DateTime.Now);

            TestConstructor1_Normal();
            TestConstructor1_MinSize();
            TestConstructor2_Normal();
            TestSize_AfterConstructor1();
            TestSize_AfterConstructor2();
            TestIndexer_GetSet();
            TestDiagonalProduct_NoParams_AllPositive();
            TestDiagonalProduct_NoParams_WithNegative();
            TestDiagonalProduct_NoParams_AllZero();
            TestDiagonalProduct_MainDiag();
            TestDiagonalProduct_MainDiag_WithZero();
            TestDiagonalProduct_Above1();
            TestDiagonalProduct_Above2();
            TestDiagonalProduct_Below1();
            TestDiagonalProduct_Below2();
            TestDiagonalProduct_Multiple();
            TestDiagonalProduct_OutOfRange();
            TestDiagonalProduct_MinMatrix2x2();

            log.WriteLine("Тест окончен: " + DateTime.Now);
            log.Close();
        }

        // TC-01
        private void TestConstructor1_Normal()
        {
            matrixTesting = new CSquareMatrix(4);
            int result = matrixTesting.Size;
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 4): " + result +
                " | " + (result == 4 ? "PASS" : "FAIL"));
        }

        // TC-02
        private void TestConstructor1_MinSize()
        {
            matrixTesting = new CSquareMatrix(2);
            int result = matrixTesting.Size;
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 2): " + result +
                " | " + (result == 2 ? "PASS" : "FAIL"));
        }

        // TC-03
        private void TestConstructor2_Normal()
        {
            double[,] src = { { 1, 2 }, { 3, 4 } };
            matrixTesting = new CSquareMatrix(src);
            double result = matrixTesting[1, 1];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат [1,1] (ожидается 4): " + result +
                " | " + (result == 4 ? "PASS" : "FAIL"));
        }

        // TC-04
        private void TestSize_AfterConstructor1()
        {
            matrixTesting = new CSquareMatrix(5);
            int result = matrixTesting.Size;
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 5): " + result +
                " | " + (result == 5 ? "PASS" : "FAIL"));
        }

        // TC-05
        private void TestSize_AfterConstructor2()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrixTesting = new CSquareMatrix(src);
            int result = matrixTesting.Size;
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 3): " + result +
                " | " + (result == 3 ? "PASS" : "FAIL"));
        }

        // TC-06
        private void TestIndexer_GetSet()
        {
            matrixTesting = new CSquareMatrix(3);
            matrixTesting[1, 2] = 7.5;
            double result = matrixTesting[1, 2];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 7.5): " + result +
                " | " + (result == 7.5 ? "PASS" : "FAIL"));
        }

        // TC-07
        private void TestDiagonalProduct_NoParams_AllPositive()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct();
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 45): " + result +
                " | " + (result == 45 ? "PASS" : "FAIL"));
        }

        // TC-08
        private void TestDiagonalProduct_NoParams_WithNegative()
        {
            double[,] src = { { -1, 2 }, { -3, 4 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct();
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 2): " + result +
                " | " + (result == 2 ? "PASS" : "FAIL"));
        }

        // TC-09
        private void TestDiagonalProduct_NoParams_AllZero()
        {
            matrixTesting = new CSquareMatrix(3);
            double[] res = matrixTesting.DiagonalProduct();
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 0): " + result +
                " | " + (result == 0 ? "PASS" : "FAIL"));
        }

        // TC-10
        private void TestDiagonalProduct_MainDiag()
        {
            double[,] src = { { 2, 0, 0 }, { 0, 3, 0 }, { 0, 0, 5 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(0);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 30): " + result +
                " | " + (result == 30 ? "PASS" : "FAIL"));
        }

        // TC-11
        private void TestDiagonalProduct_MainDiag_WithZero()
        {
            double[,] src = { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 4 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(0);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 0): " + result +
                " | " + (result == 0 ? "PASS" : "FAIL"));
        }

        // TC-12
        private void TestDiagonalProduct_Above1()
        {
            double[,] src = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(1);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 168): " + result +
                " | " + (result == 168 ? "PASS" : "FAIL"));
        }

        // TC-13
        private void TestDiagonalProduct_Above2()
        {
            double[,] src = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(2);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 24): " + result +
                " | " + (result == 24 ? "PASS" : "FAIL"));
        }

        // TC-14
        private void TestDiagonalProduct_Below1()
        {
            double[,] src = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(-1);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 750): " + result +
                " | " + (result == 750 ? "PASS" : "FAIL"));
        }

        // TC-15
        private void TestDiagonalProduct_Below2()
        {
            double[,] src = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(-2);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат (ожидается 126): " + result +
                " | " + (result == 126 ? "PASS" : "FAIL"));
        }

        // TC-16
        private void TestDiagonalProduct_Multiple()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(0, 1, -1);
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": diag0 (ожидается 45): " + res[0] +
                " | " + (res[0] == 45 ? "PASS" : "FAIL"));
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": diag+1 (ожидается 12): " + res[1] +
                " | " + (res[1] == 12 ? "PASS" : "FAIL"));
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": diag-1 (ожидается 32): " + res[2] +
                " | " + (res[2] == 32 ? "PASS" : "FAIL"));
        }

        // TC-17
        private void TestDiagonalProduct_OutOfRange()
        {
            double[,] src = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(3);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат diag+3 (ожидается 0): " + result +
                " | " + (result == 0 ? "PASS" : "FAIL"));
        }

        // TC-18
        private void TestDiagonalProduct_MinMatrix2x2()
        {
            double[,] src = { { 3, 7 }, { 2, 5 } };
            matrixTesting = new CSquareMatrix(src);
            double[] res = matrixTesting.DiagonalProduct(0);
            double result = res[0];
            log.WriteLine(DateTime.Now + " Метод: " +
                System.Reflection.MethodInfo.GetCurrentMethod() +
                ": Результат 2x2 (ожидается 15): " + result +
                " | " + (result == 15 ? "PASS" : "FAIL"));
        }
    }
}