using System.Collections.Generic;

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
            int[] edge = InputReader.ArrayInt();
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
        this.grid = InputReader.MatrixChar(row, col);
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
