using System.Collections.Generic;

//単純操作
//スワップ
public class Swap
{
    //スワップ
    public static void Array<T>(T[] arr, int i, int j) => (arr[i], arr[j]) = (arr[j], arr[i]);
    public static void List<T>(List<T> list, int i, int j) => (list[i], list[j]) = (list[j], list[i]);
    public static void Matrix2D<T>(T[,] matrix, int r1, int c1, int r2, int c2) =>
        (matrix[r1, c1], matrix[r2, c2]) = (matrix[r2, c2], matrix[r1, c1]);
    public static void NestedList<T>(List<List<T>> nestedList, int r1, int c1, int r2, int c2) =>
        (nestedList[r1][c1], nestedList[r2][c2]) = (nestedList[r2][c2], nestedList[r1][c1]);

    //行の入れ替え
    public static void Row<T>(T[,] matrix, int row1, int row2)
    {
        int colCount = matrix.GetLength(1);
        for (int c = 0; c < colCount; c++)
        {
            (matrix[row1, c], matrix[row2, c]) = (matrix[row2, c], matrix[row1, c]);
        }
    }
    public static void Row<T>(List<List<T>> nestedList, int row1, int row2)
    {
        (nestedList[row1], nestedList[row2]) = (nestedList[row2], nestedList[row1]);
    }

    //列の入れ替え
    public static void Column<T>(T[,] matrix, int col1, int col2)
    {
        int rowCount = matrix.GetLength(0);
        for (int r = 0; r < rowCount; r++)
        {
            (matrix[r, col1], matrix[r, col2]) = (matrix[r, col2], matrix[r, col1]);
        }
    }
    public static void Column<T>(List<List<T>> nestedList, int col1, int col2)
    {
        int rowCount = nestedList.Count;
        for (int r = 0; r < rowCount; r++)
        {
            (nestedList[r][col1], nestedList[r][col2]) = (nestedList[r][col2], nestedList[r][col1]);
        }
    }
}
