using System;

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
