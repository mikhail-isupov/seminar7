using System;

namespace Seminar7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args.Length == 0) Print("Введите номер задачи в качестве параметра командной строки.");
            else switch(args[0])
            {
                case "47": task47(); break;
                case "50": task50(); break;
                case "52": task52(); break;
                default: Print("Такой задачи нет"); break;
            }

        }

        static void task47()
        // Cоздаем двумерный массив rows x columns, заполненный случайными вещественными числами (minValue..maxValue) и печатаем его. 
        
        {
            int rows = GetInt("Введите число строк");
            int columns = GetInt("Введите число столбцов");
            double minValue = GetDouble("Введите минимальное значение элемента массива");
            double maxValue = GetDouble("Введите максимальное значение элемента массива");

            double[,] matrix = CreateMatrix(rows, columns, minValue, maxValue);

            PrintMatrix(matrix);

        }

        static void task50()
        // Cоздаем двумерный массив rows x columns, заполненный случайными вещественными числами (minValue..maxValue) и печатаем его. 
        // Вводим позицию массива и возвращаем его либо Double.MaxValue если его нет
        {
            int rows = GetInt("Введите число строк");
            int columns = GetInt("Введите число столбцов");
            double minValue = GetDouble("Введите минимальное значение элемента массива");
            double maxValue = GetDouble("Введите максимальное значение элемента массива");

            double[,] matrix = CreateMatrix(rows, columns, minValue, maxValue);

            PrintMatrix(matrix);

            int row = GetInt("Введите номер строки элемента матрицы");
            int column = GetInt("Введите номер столбца элемента матрицы");

            double result = GetMatrixElement(matrix, row, column);
            
            if (result == Double.MaxValue) Print("Позиция элемента выходит за границы матрицы");
            else Print("Значение элемента матрицы = " + result);
        }

        static void task52()
        // Cоздаем двумерный массив rows x columns, заполненный случайными вещественными числами (minValue..maxValue) и печатаем его. 
        // Считаем среднее для каждого столбца
        {
            int rows = GetInt("Введите число строк");
            int columns = GetInt("Введите число столбцов");
            double minValue = GetDouble("Введите минимальное значение элемента массива");
            double maxValue = GetDouble("Введите максимальное значение элемента массива");

            double[,] matrix = CreateMatrix(rows, columns, minValue, maxValue);

            PrintMatrix(matrix);

            MeanColumns(matrix);
        }

        static void Print (string message)
        {
            Console.WriteLine(message);
        }

        static int GetInt(string message)
        // Считывание целочисленного значения 
        {
            Print(message);
            int result = int.Parse(Console.ReadLine());
            return result;
        }

         static double GetDouble(string message)
        // Считывание вещественного значения 
        {
            Print(message);
            double result = Double.Parse(Console.ReadLine());
            return result;
        }

        static double[,] CreateMatrix(int rows, int columns, double minValue, double maxValue)
        // Создание матрицы и заполнение случайными числами
        {
            double[,] matrix = new double[rows, columns];
            Random number = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++) matrix[i,j] = (maxValue - minValue) * number.NextDouble() + minValue;
            }

            return matrix;
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string matrixRow = String.Empty;
                
                for (int j = 0; j < matrix.GetLength(1); j++) matrixRow += " " + matrix[i,j];

                Print(matrixRow);
            }
        }

        static double GetMatrixElement(double[,] matrix, int row, int column)
        {
            if (row < 1 || row > matrix.GetLength(0) || column < 1 || column > matrix.GetLength(1)) return Double.MaxValue;

            return matrix[row - 1, column - 1];
        }

        static void MeanColumns(double[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                double sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++ ) sum += matrix[i,j];
                double mean = sum / matrix.GetLength(0);
                Print($"Среднее в колонке {j + 1} = {mean}");
            }
        }
    }
}
