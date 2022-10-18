namespace test;

public static class MatrixExtentions
{
    public static int[] GetColumn(this int[][] matrix, int column)
    {
        var values = new List<int>(matrix.Length);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            values.Add(matrix[i][column]);
        }

        return values.ToArray();
    }
}
