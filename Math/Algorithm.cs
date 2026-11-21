using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 計算アルゴリズム
/// </summary>
public class Algorithm
{
    /// <summary>
    /// 素数判定
    /// </summary>
    /// <param name="num">判定する数値</param>
    /// <returns>true = 素数</returns>
    public static bool IsPrime(int num)
    {
        var prime = true;
        if (num % 2 == 0)
            prime = false;
        else
        {
            for (int i = 3; i * i <= num; i += 2)
            {
                if (num % i == 0)
                {
                    prime = false;
                    break;
                }
            }
        }
        return prime;
    }

    /// <summary>
    /// 約数全列挙
    /// </summary>
    /// <param name="num">判定する数値</param>
    /// <returns>約数リスト(昇順)</returns>
    public static List<int> GetDivisors(int num)
    {
        var set = new HashSet<int>();
        for (int i = 1; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                set.Add(i);
                set.Add(num / i);
            }
        }
        var result = set.ToList();
        result.Sort();
        return result;
    }

    /// <summary>
    /// 最大公約数(int)
    /// </summary>
    /// <param name="a">判定値A</param>
    /// <param name="b">判定値B</param>
    /// <returns>最大公約数</returns>
    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// 最大公約数(long)
    /// </summary>
    /// <param name="a">判定値A</param>
    /// <param name="b">判定値B</param>
    /// <returns>最大公約数</returns>
    public static long GCDLong(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// 素因数分解(int)
    /// </summary>
    /// <param name="n">判定値</param>
    /// <returns>素因数リスト</returns>
    public static List<int> Factorize(int n)
    {
        var factors = new List<int>();
        while (true)
        {
            if (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }
            else
                break;
        }

        int i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
            else
            {
                i += 2;
            }
        }

        if (factors.Count == 0 || n != 1)
            factors.Add(n);

        return factors;
    }

    /// <summary>
    /// 素因数分解(long)
    /// </summary>
    /// <param name="n">判定値</param>
    /// <returns>素因数リスト</returns>
    public static List<long> FactorizeLong(long n)
    {
        var factors = new List<long>();
        while (true)
        {
            if (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }
            else
                break;
        }

        long i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
            else
            {
                i += 2;
            }
        }

        if (factors.Count == 0 || n != 1)
            factors.Add(n);

        return factors;
    }
}
