using System;
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
