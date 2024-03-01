/*
Задача:
Создать матрицу и развернуть ее по часовой стрелке на заданное количество углов 90С (1,2,3,4) 
*/

using System.Globalization;

void Main()
{
    int[,] matrix = GenerateMatrix(2, 3, 10, 99);
    Console.WriteLine("Исходная матрица");
    PrintMatrix(matrix);
    // int[,] rotatedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
    Console.Write("Укажите количество поворотов матрицы: ");
    int corners = Convert.ToInt32(Console.ReadLine());
    Console.Write("Для поворота массива в нужном направлении используйте стрелки влево или вправо: ");

    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    if (keyInfo.Key == ConsoleKey.LeftArrow)
    {
        int[,] Matrix = LeftRotatedMatrix(matrix);
        for (int c = 1; c < corners; c++)
        {
            Matrix = LeftRotatedMatrix(Matrix);
        }
        Console.WriteLine();
        PrintMatrix(Matrix);
    }

    if (keyInfo.Key == ConsoleKey.RightArrow)
    {
        int[,] Matrix = RightRotatedMatrix(matrix);
        for (int c = 1; c < corners; c++)
        {
            Matrix = RightRotatedMatrix(Matrix);
        }
        Console.WriteLine();
        PrintMatrix(Matrix);
    }
}
Main();



// Функции_________________________________________

    int[,] RightRotatedMatrix(int[,] matrix) // Поворот массива по часовой стрелке
    {
        int[,] rotatedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
        int a = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int b = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                rotatedMatrix[a, b] = matrix[matrix.GetLength(0) - 1 - i, j];
                b++;
            }
            a++;
        }
        return rotatedMatrix;
    }

    int[,] LeftRotatedMatrix(int[,] matrix) // Поворот массива против часовой стрелки
    {
        int[,] rotatedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
        int a = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int b = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                rotatedMatrix[a, b] = matrix[i, matrix.GetLength(1) - 1 - j];
                b++;
            }
            a++;
        }
        return rotatedMatrix;
    }


    int[,] GenerateMatrix(int row, int column, int leftBound, int rightBound) // Генерация двумерного массива случайных целых чисел
    {
        int[,] newMatrix = new int[row, column];
        Random rnd = new Random();

        for (int i = 0; i < newMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < newMatrix.GetLength(1); j++)
            {
                newMatrix[i, j] = rnd.Next(leftBound, rightBound + 1);
            }
        }
        return newMatrix;
    }

    void PrintMatrix(int[,] matrix) // Печать двумерного массива
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine("");

        }
    }
