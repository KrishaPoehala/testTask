namespace test;

public static class MatrixHelper
{
    public static int[][] Generate(int size)
    {
        var matrix = new int[size][];
        for (int i = 0; i < size; i++)
        {
            matrix[i] = new int[size];
        }
        var rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i][j] = rnd.Next(0, 2);
            }
        }

        return matrix;
    }

    public static void Print(int[][] matrix)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + "\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
