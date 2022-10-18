using test;

var matrix = MatrixHelper.Generate(10);
MatrixHelper.Print(matrix);
DeleteAllSeries(matrix);
MatrixHelper.Print(matrix);

void DeleteAllSeries(int[][] matrix)
{
    while (true)
    {
        if (ColumnSeriesAreNotEmpty(matrix))
        {
            HandleColumns(matrix);
            continue;
        }

        if (RowSeriesAreNotEmpty(matrix))
        {
            HandleRows(matrix);
            continue;
        }

        break;
    }
}

void HandleColumns(int[][] matrix)
{
    for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
    {
        var series = GetSeries(matrix.GetColumn(i));
        if (series.Any() == false) // I hate using !
            continue;

        MoveColumn(matrix, series, column: i);
    }
}

void MoveColumn(int[][] matrix, IEnumerable<(int Start, int Count)> series, int column)
{
    foreach (var seria in series)
    {
        MoveColumnByOneSeria(matrix, seria, column);
    }
}

void MoveColumnByOneSeria(int[][] matrix, (int Start, int Count) seria, int column)
{
    for (int i = seria.Start - 1; i >= 0; i--)
    {
        matrix[i][column] = matrix[i + seria.Count][column];
    }

    for (int i = 0; i < seria.Count; i++)
    {
        matrix[i][column] = Random.Shared.Next(0, 2);
    }
}

void MoveRowByOneSeria(int[][] matrix, (int Start, int Count) seria, int row)
{
    for (int i = row; i >= 0; i--)
    {
        for (int j = seria.Start; j < seria.Start + seria.Count; j++)
        {
            if (i != 0)
            {
                matrix[i][j] = matrix[i - 1][j];
            }
            else
            {
                matrix[i][j] = Random.Shared.Next(0, 2);
            }
        } 
    }
}
void HandleRows(int[][] matrix)
{
    for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
    {
        var series = GetSeries(matrix[i]);
        if (series.Any() == false)
        {
            continue;
        }

        MoveRow(matrix, series, row: i);
    }
}

bool RowSeriesAreNotEmpty(int[][] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        var series = GetSeries(matrix[i]).ToList();
        if (series.Any())
        {
            return true;
        }
    }

    return false;
}

bool ColumnSeriesAreNotEmpty(int[][] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        var series = GetSeries(matrix.GetColumn(i));
        if (series.Any())
        {
            return true;
        }
    }

    return false;
}

void MoveRow(int[][] matrix, IEnumerable<(int Start, int Count)> series, int row)
{
    foreach (var item in series)
    {
        MoveRowByOneSeria(matrix, item, row);
    }
}


IEnumerable<(int Start, int Count)> GetSeries(int[] arr)
{
    for (int i = 0; i < arr.Length;)
    {
        var element = arr[i];
        var count = arr[i..].TakeWhile(x => element == x).Count();
        if (count >= 3)
        {
            yield return (i, count);
        }

        i += count;
    }  
}




