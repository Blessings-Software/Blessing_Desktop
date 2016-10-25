using Morphing;

using System;
using System.Collections.Generic;
using System.Drawing;

namespace TextMorphing.Controls
{
    public class MorphData
    {
        public Bitmap Source { get; }

        private byte[][] original;
        private byte[][] outlines;

        public MorphData(Bitmap src)
        {
            Source = src;

            original = src.ToBit();
            outlines = original.GetOutline();
        }

        public IEnumerable<Point> Trace()
        {
            var buffer = outlines.Copy();

            int width = Source.Width;
            int height = Source.Height;
            
            var clockwise = new Point[]
            {
                new Point(0, -1),
                new Point(1, -1),
                new Point(1, 0),
                new Point(1, 1),
                new Point(0, 1),
                new Point(-1, 1),
                new Point(-1, 0),
                new Point(-1, -1),
            };

            byte visited = 8;
            var wQue = new Queue<Point>();

            Func<Point, Point> getClosedPoint =
                (p) =>
                {
                    double d = Source.Width * Source.Height;
                    Point cpt = new Point(-1, -1);

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            if (buffer[x][y] != visited && buffer[x][y] > 0)
                            {
                                var dt = Distance(p, new Point(x, y));
                                if (d > dt)
                                {
                                    d = dt;
                                    cpt = new Point(x, y);
                                }
                            }
                        }
                    }


                    return cpt;
                };

            Func<Point, bool> isBit =
                p => (p.X >= 0 && p.X < width && p.Y >= 0 && p.Y < height);

            Func<Point, bool> isVisited =
                p =>
                {
                    if (isBit(p))
                        return buffer[p.X][p.Y] == visited;

                    return true;
                };

            Func<Point, Point> getNextClockwise =
                p =>
                {
                    for (int i = 0; i < clockwise.Length; i++)
                    {
                        var pt = Point.Add(p, (Size)clockwise[i]);

                        if (!isVisited(pt) && buffer[pt.X][pt.Y] > 0)
                            return pt;
                    }

                    return new Point(-1, -1);
                };

            Point lPt = Point.Empty;
            Point npt;

            while ((npt = getClosedPoint(lPt)) != new Point(-1, -1))
            {
                wQue.Enqueue(npt);
                while (wQue.Count > 0)
                {
                    var v = wQue.Dequeue();
                    var nv = getNextClockwise(v);

                    lPt = v;

                    if (outlines[v.X][v.Y] > 0)
                        yield return v;

                    buffer[v.X][v.Y] = visited;

                    if (nv.X == -1 && nv.Y == -1)
                        break;

                    wQue.Enqueue(nv);
                }
            }
        }

        public static double Distance(Point pt1, Point pt2)
        {
            return Math.Sqrt(Math.Pow(pt1.X - pt2.X, 2) + Math.Pow(pt1.Y - pt2.Y, 2));
        }

        public static double Distance(PointF pt1, PointF pt2)
        {
            return Math.Sqrt(Math.Pow(pt1.X - pt2.X, 2) + Math.Pow(pt1.Y - pt2.Y, 2));
        }
    }
}
