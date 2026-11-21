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
public class InputReader
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

//ここ以降を変更

public class Program
{
    public static readonly long mod = 1000000007;
    public static readonly double pi = Math.PI;

    public struct Input
    {
        public int N;
        public int[] Ar;
        public int[] Br;
    }

    private static Input GetInput()
    {
        var input = new Input();
        input.N = InputReader.Int();
        input.Ar = InputReader.ArrayInt();
        input.Br = InputReader.ArrayInt();
        return input;
    }

    public static void Main()
    {
        const string SampleInput = @"6
1 4 1 4 2 1
1 4 1 1 4 2
";
        // 提出時はコメントアウト
        // Console.SetIn(new StringReader(SampleInput));
        var input = GetInput();
        int n = input.N;
    }
}
