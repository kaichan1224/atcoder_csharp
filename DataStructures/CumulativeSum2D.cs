#region 2次元累積和
public class CumulativeSum2D
{
    private int[,] _sum;

    public CumulativeSum2D(int[,] arr)
    {
        int low = arr.GetLength(0);
        int col = arr.GetLength(1);
        _sum = new int[low + 1, col + 1];

        for (int i = 0; i < low; i++)
        {
            for (int j = 0; j < col; j++)
            {
                _sum[i + 1, j + 1] = _sum[i + 1, j]
                                + _sum[i, j + 1]
                                + arr[i, j]
                                - _sum[i, j];
            }
        }
    }

    public int GetRangeSum(int top, int bottom, int left, int right)
    {
        return _sum[bottom, right] - _sum[top, right]
- _sum[bottom, left] + _sum[top, left];
    }
}
#endregion 2次元累積和
