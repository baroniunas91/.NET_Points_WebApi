using Points.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Services
{
    public class SquareService
    {
        //public int SquareCount(Point[] input)
        //{
        //    int count = 0;

        //    HashSet<Point> set = new HashSet<Point>();
        //    foreach (var point in input)
        //        set.Add(point);

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        for (int j = 0; j < input.Length; j++)
        //        {
        //            if (i == j)
        //                continue;
        //            //For each Point i, Point j, check if b&d exist in set.
        //            Point[] DiagVertex = GetRestPints(input[i], input[j]);
        //            if (set.Contains(DiagVertex[0]) && set.Contains(DiagVertex[1]))
        //            {
        //                count++;
        //            }
        //        }
        //    }
        //    return count;

        //}

        //public Point[] GetRestPints(Point a, Point c)
        //{
        //    Point[] res = new Point[2];

        //    int midX = (a.Xcoordinate + c.Ycoordinate) / 2;
        //    int midY = (a.Ycoordinate + c.Ycoordinate) / 2;

        //    int Ax = a.Xcoordinate - midX;
        //    int Ay = a.Ycoordinate - midY;
        //    int bX = midX - Ay;
        //    int bY = midY + Ax;
        //    Point b = new Point();
        //    b.Xcoordinate = bX;
        //    b.Ycoordinate = bY;

        //    int cX = (c.Xcoordinate - midX);
        //    int cY = (c.Ycoordinate - midY);
        //    int dX = midX - cY;
        //    int dY = midY + cX;
        //    Point d = new Point();
        //    d.Xcoordinate = dX;
        //    d.Ycoordinate = dY;

        //    res[0] = b;
        //    res[1] = d;
        //    return res;
        //}




        // A utility function to find square of distance 
        // from point 'p' to point 'q' 
        static int distSq(Point p, Point q)
        {
            return (p.Xcoordinate - q.Xcoordinate) * (p.Xcoordinate - q.Xcoordinate) + (p.Ycoordinate - q.Ycoordinate) * (p.Ycoordinate - q.Ycoordinate);
        }

        // This function returns true if (p1, p2, p3, p4) form a 
        // square, otherwise false 
        public static bool IsSquare(Point p1, Point p2, Point p3, Point p4)
        {
            int d2 = distSq(p1, p2); // from p1 to p2 
            int d3 = distSq(p1, p3); // from p1 to p3 
            int d4 = distSq(p1, p4); // from p1 to p4 

            if (d2 == 0 || d3 == 0 || d4 == 0)
                return false;

            // If lengths if (p1, p2) and (p1, p3) are same, then 
            // following conditions must met to form a square. 
            // 1) Square of length of (p1, p4) is same as twice 
            // the square of (p1, p2) 
            // 2) Square of length of (p2, p3) is same 
            // as twice the square of (p2, p4) 
            if (d2 == d3 && 2 * d2 == d4
                && 2 * distSq(p2, p4) == distSq(p2, p3))
            {
                return true;
            }

            // The below two cases are similar to above case 
            if (d3 == d4 && 2 * d3 == d2
                && 2 * distSq(p3, p2) == distSq(p3, p4))
            {
                return true;
            }
            if (d2 == d4 && 2 * d2 == d3
                && 2 * distSq(p2, p3) == distSq(p2, p4))
            {
                return true;
            }
            return false;
        }
    }
}
