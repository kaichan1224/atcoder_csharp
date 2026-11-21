#region 累積和
public class CumulativeSum1D
{
    private long[] _sum;

    public CumulativeSum1D(long[] arr)
    {
        _sum = new long[arr.Length + 1];
        for (int i = 0; i < arr.Length; i++)
        {
            _sum[i + 1] = _sum[i] + arr[i];
        }
    }

    public long GetRangeSum(int l, int r)
    {
        return _sum[r] - _sum[l];
    }
}
#endregion 累積和
