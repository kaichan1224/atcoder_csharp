using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


// AtcoderのTemplate
// https://github.com/kaichan1224/atcoder_csharp/blob/main/Template.cs


#region 入力受け取りフォーマット
/// <summary>
/// 入力受け取りクラス
/// </summary>
public class Input
{
    /// <summary>
    /// 単一整数(int)
    /// </summary>
    /// <returns></returns>
    public static int Int() => int.Parse(Console.ReadLine()!);

    /// <summary>
    /// 単一整数(long)
    /// </summary>
    /// <returns></returns>
    public static long Long() => long.Parse(Console.ReadLine()!);

    /// <summary>
    /// 単一文字列
    /// </summary>
    /// <returns></returns>
    public static string String() => Console.ReadLine()!;

    /// <summary>
    /// 整数配列(int)
    /// </summary>
    /// <returns></returns>
    public static int[] ArrayInt()
    {
        ReadOnlySpan<char> line = Console.ReadLine()!.AsSpan();
        int count = CountTokens(line);
        var values = new int[count];
        int index = 0;
        for (int i = 0; i < count; i++)
        {
            SkipWhitespace(line, ref index);
            int start = index;
            while (index < line.Length && !char.IsWhiteSpace(line[index])) index++;
            values[i] = int.Parse(line.Slice(start, index - start));
        }
        return values;
    }

    /// <summary>
    /// 整数配列(long)
    /// </summary>
    /// <returns></returns>
    public static long[] ArrayLong()
    {
        ReadOnlySpan<char> line = Console.ReadLine()!.AsSpan();
        int count = CountTokens(line);
        var values = new long[count];
        int index = 0;
        for (int i = 0; i < count; i++)
        {
            SkipWhitespace(line, ref index);
            int start = index;
            while (index < line.Length && !char.IsWhiteSpace(line[index])) index++;
            values[i] = long.Parse(line.Slice(start, index - start));
        }
        return values;
    }

    private static int CountTokens(ReadOnlySpan<char> line)
    {
        int count = 0;
        int index = 0;
        while (index < line.Length)
        {
            SkipWhitespace(line, ref index);
            if (index == line.Length) break;
            count++;
            while (index < line.Length && !char.IsWhiteSpace(line[index])) index++;
        }
        return count;
    }

    private static void SkipWhitespace(ReadOnlySpan<char> line, ref int index)
    {
        while (index < line.Length && char.IsWhiteSpace(line[index])) index++;
    }

    /// <summary>
    /// 文字配列(空白区切り)
    /// </summary>
    /// <returns></returns>
    public static string[] ArrayString() => Console.ReadLine()!.Split(' ');

    /// <summary>
    /// 整数リスト(int)
    /// </summary>
    /// <returns></returns>
    public static List<int> ListInt()
    {
        ReadOnlySpan<char> line = Console.ReadLine()!.AsSpan();
        var values = new List<int>(CountTokens(line));
        int index = 0;
        while (index < line.Length)
        {
            SkipWhitespace(line, ref index);
            if (index == line.Length) break;
            int start = index;
            while (index < line.Length && !char.IsWhiteSpace(line[index])) index++;
            values.Add(int.Parse(line.Slice(start, index - start)));
        }
        return values;
    }

    /// <summary>
    /// 文字列リスト(空白区切り)
    /// </summary>
    /// <returns></returns>
    public static List<string> ListString() => ArrayString().ToList();

    /// <summary>
    /// 文字配列(1文字区切り)
    /// </summary>
    /// <returns></returns>
    public static char[] ArrayChar() => Console.ReadLine()!.ToCharArray();

    /// <summary>
    /// 文字リスト(1文字区切り)
    /// </summary>
    /// <returns></returns>
    public static List<char> ListChar() => Console.ReadLine()!.ToCharArray().ToList();

    /// <summary>
    /// 複数行整数リスト(int)
    /// </summary>
    /// <param name="row">行数</param>
    /// <returns></returns>
    public static List<List<int>> NestedInt(int row)
    {
        var input = new List<List<int>>();
        for (int i = 0; i < row; i++)
        {
            List<int> list = ListInt();
            input.Add(list);
        }
        return input;
    }

    /// <summary>
    /// 複数行文字列リスト(空白区切り)
    /// </summary>
    /// <param name="row">行数</param>
    /// <returns></returns>
    public static List<List<string>> NestedString(int row)
    {
        var input = new List<List<string>>();
        for (int i = 0; i < row; i++)
        {
            List<string> list = ListString();
            input.Add(list);
        }
        return input;
    }

    /// <summary>
    /// 複数行文字列リスト(1文字区切り)
    /// </summary>
    /// <param name="row">行数</param>
    /// <returns></returns>
    public static List<List<char>> NestedChar(int row)
    {
        var input = new List<List<char>>();
        for (int i = 0; i < row; i++)
        {
            List<char> list = ListChar();
            input.Add(list);
        }
        return input;
    }

    /// <summary>
    /// 2次元整数配列(int)
    /// </summary>
    /// <param name="row">行数</param>
    /// <param name="col">列数</param>
    /// <returns></returns>
    public static int[,] MatrixInt(int row, int col)
    {
        var input = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            int[] rowData = ArrayInt();
            for (int j = 0; j < col; j++)
            {
                input[i, j] = rowData[j];
            }
        }
        return input;
    }

    /// <summary>
    /// 2次元文字配列(空白区切り)
    /// </summary>
    /// <param name="row">行数</param>
    /// <param name="col">列数</param>
    /// <returns></returns>
    public static string[,] MatrixString(int row, int col)
    {
        var input = new string[row, col];
        for (int i = 0; i < row; i++)
        {
            string[] rowData = ArrayString();
            for (int j = 0; j < col; j++)
            {
                input[i, j] = rowData[j];
            }
        }
        return input;
    }

    /// <summary>
    /// 2次元文字配列(1文字区切り)
    /// </summary>
    /// <param name="row">行数</param>
    /// <param name="col">列数</param>
    /// <returns></returns>
    public static char[,] MatrixChar(int row, int col)
    {
        var input = new char[row, col];
        for (int i = 0; i < row; i++)
        {
            char[] rowData = ArrayChar();
            for (int j = 0; j < col; j++)
            {
                input[i, j] = rowData[j];
            }
        }
        return input;
    }
}
#endregion 入力受け取りフォーマット

#region 出力簡略化
/// <summary>
/// 出力フォーマット
/// </summary>
public class Output
{
    /// <summary>
    /// 出力実行
    /// </summary>
    /// <param name="output">出力するデータ</param>
    /// <param name="separator">配列の要素の間に挟む文字列(default = " ")</param>
    public static void Print(object? output, string separator = " ")
    {
        WriteFormatted(Console.Out, output, separator);
        Console.WriteLine();
    }

    internal static void WriteFormatted(TextWriter writer, object? obj, string separator)
    {
        if (obj == null)
        {
            writer.Write("null");
            return;
        }

        // 単一データの出力
        if (obj is string || obj is char || obj.GetType().IsPrimitive || obj is decimal)
        {
            writer.Write(obj);
            return;
        }

        // 二次元配列
        if (obj is Array array && array.Rank == 2)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (i > 0) writer.WriteLine();
                for (int j = 0; j < cols; j++)
                {
                    if (j > 0) writer.Write(separator);
                    WriteFormatted(writer, array.GetValue(i, j), separator);
                }
            }
            return;
        }

        // IEnumerable
        if (obj is System.Collections.IEnumerable enumerable)
        {
            var iterator = enumerable.GetEnumerator();
            try
            {
                if (!iterator.MoveNext()) return;
                object? item = iterator.Current;
                bool hasNestedCollection = item is System.Collections.IEnumerable && item is not string;
                WriteFormatted(writer, item, separator);
                while (iterator.MoveNext())
                {
                    writer.Write(hasNestedCollection ? Environment.NewLine : separator);
                    WriteFormatted(writer, iterator.Current, separator);
                }
            }
            finally
            {
                (iterator as IDisposable)?.Dispose();
            }
            return;
        }

        writer.Write(obj);
    }
}
#endregion 出力簡略化

#region デバッグログ
/// <summary>
/// デバッグ用ログ。標準エラーに出力するため、提出時の標準出力に影響しない。
/// </summary>
public class Log
{
    /// <summary>
    /// 複数の値を空白区切りで標準エラーに出力する。
    /// 配列や入れ子のコレクションも再帰的に整形する。
    /// </summary>
    public static void Print(params object[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (i > 0) Console.Error.Write(' ');
            Output.WriteFormatted(Console.Error, values[i], " ");
        }
        Console.Error.WriteLine();
    }
}
#endregion デバッグログ

#region 便利ツール
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
#endregion 便利ツール

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

#region 幾何学
public class Geometry
{
    public struct Point
    {
        public long X, Y;

        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }
    }

    private static long Cross(Point a, Point b, Point c)
    {
        long dx1 = b.X - a.X;
        long dy1 = b.Y - a.Y;
        long dx2 = c.X - a.X;
        long dy2 = c.Y - a.Y;
        return dx1 * dy2 - dy1 * dx2;
    }

    private static int CCW(Point a, Point b, Point c)
    {
        long cross = Cross(a, b, c);
        if (cross > 0) return 1;
        if (cross < 0) return -1;
        return 0;
    }

    public static bool IsIntersect(Point a1, Point a2, Point b1, Point b2)
    {
        int ab1 = CCW(a1, a2, b1);
        int ab2 = CCW(a1, a2, b2);
        int cd1 = CCW(b1, b2, a1);
        int cd2 = CCW(b1, b2, a2);

        if (ab1 * ab2 < 0 && cd1 * cd2 < 0)
            return true;
        else
            return false;
    }
}
#endregion 幾何学

#region グラフ理論
// 無向グラフ (メモリ負荷削減のため HashSet から List<int> に変更)
public class Graph
{
    protected List<List<int>> _graph;
    protected readonly int _vertex, _E;
    protected int[] _dist;

    public int[] Dist => _dist;

    public Graph(int V, int E)
    {
        this._vertex = V;
        this._E = E;
        this._dist = new int[V];
        this._graph = new List<List<int>>();
        for (int i = 0; i < _vertex; i++)
            _graph.Add(new List<int>());
        for (int i = 0; i < _E; i++)
        {
            int[] edge = Input.ArrayInt();
            int x = edge[0] - 1;
            int y = edge[1] - 1;
            Set(x, y);
        }
    }

    public List<int> Get(int v) => _graph[v];

    public void Set(int x, int y)
    {
        _graph[x].Add(y);
        _graph[y].Add(x);
    }

    public void BFS(int start)
    {
        this._dist = new int[_vertex];
        for (int i = 0; i < _vertex; i++)
            _dist[i] = -1;

        var q = new Queue<int>();
        q.Enqueue(start);
        _dist[start] = 0;

        while (q.Count > 0)
        {
            var visit = q.Dequeue();
            int cnt = _dist[visit];
            foreach (int v in _graph[visit])
            {
                if (_dist[v] == -1)
                {
                    _dist[v] = cnt + 1;
                    q.Enqueue(v);
                }
            }
        }
    }
}

//グリッド
public class GridGraph
{
    private readonly char[,] grid;
    private readonly int row, col;
    private int[] dr = { -1, 0, 1, 0 };
    private int[] dc = { 0, 1, 0, -1 };
    private int[,] dist;

    public int[,] Dist => dist;

    public GridGraph(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.dist = new int[row, col];
        this.grid = Input.MatrixChar(row, col);
    }

    public char Get(int R, int C) => grid[R, C];

    public void Set(int R, int C, char value) => grid[R, C] = value;

    public bool InBounds(int R, int C) => 0 <= R && R < row && 0 <= C && C < col;

    public void BFS(int start_R, int start_C, char possible)
    {
        this.dist = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                dist[i, j] = -1;
            }
        }

        var q = new Queue<(int, int)>();
        q.Enqueue((start_R, start_C));
        dist[start_R, start_C] = 0;

        while (q.Count > 0)
        {
            var (R, C) = q.Dequeue();

            for (int d = 0; d < dr.Length; d++)
            {
                int nR = R + dr[d];
                int nC = C + dc[d];
                if (InBounds(nR, nC))
                {
                    if (dist[nR, nC] == -1)
                    {
                        if (Get(nR, nC) == possible)
                        {
                            dist[nR, nC] = dist[R, C] + 1;
                            q.Enqueue((nR, nC));
                        }
                    }
                }
            }
        }
    }
}
#endregion グラフ理論

#region Union-Find
public class UnionFind
{
    private int[] _parent;
    private int[] _rank;

    public UnionFind(int size)
    {
        _parent = new int[size];
        _rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            _parent[i] = i;
            _rank[i] = 0;
        }
    }

    public int Find(int x)
    {
        if (_parent[x] != x)
        {
            _parent[x] = Find(_parent[x]);
        }
        return _parent[x];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY)
            return;

        if (_rank[rootX] < _rank[rootY])
        {
            _parent[rootX] = rootY;
        }
        else if (_rank[rootX] > _rank[rootY])
        {
            _parent[rootY] = rootX;
        }
        else
        {
            _parent[rootY] = rootX;
            _rank[rootX]++;
        }
    }

    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
#endregion Union-Find

#region セグメント木
public class SegmentTree<T>
{
    private readonly int _size;
    private readonly T _identity;
    private readonly T[] _tree;
    private readonly Func<T, T, T> _merge;

    public SegmentTree(int n, T identity, Func<T, T, T> merge)
    {
        this._identity = identity;
        this._merge = merge;

        int sz = 1;
        while (sz < n) sz <<= 1;
        this._size = sz;

        _tree = new T[2 * _size];
        for (int i = 0; i < _tree.Length; i++)
        {
            _tree[i] = _identity;
        }
    }

    public T Get(int index)
    {
        index += _size;
        return _tree[index];
    }

    public void Update(int index, T value)
    {
        index += _size;
        _tree[index] = value;

        while (index > 1)
        {
            index >>= 1;
            _tree[index] = _merge(_tree[2 * index], _tree[2 * index + 1]);
        }
    }

    public T Query(int l, int r)
    {
        l += _size;
        r += _size;

        T leftResult = _identity;
        T rightResult = _identity;

        while (l < r)
        {
            if ((l & 1) == 1)
                leftResult = _merge(leftResult, _tree[l++]);
            if ((r & 1) == 1)
                rightResult = _merge(_tree[--r], rightResult);
            l >>= 1;
            r >>= 1;
        }

        return _merge(leftResult, rightResult);
    }

    public void Test()
    {
        Output.Print(_tree);
    }
}
#endregion セグメント木


//ここ以降を変更

public class Program
{
    public static readonly long mod = 1000000007;
    public static readonly double pi = Math.PI;

    // 問題文の入力例をここにそのまま貼り付ける。
    private const string SampleInput = @"
";

    public static void Main()
    {
        // ローカル確認時だけコメントを外す。提出時はコメントアウトする。
        Console.SetIn(new StringReader(SampleInput));
    }
}
