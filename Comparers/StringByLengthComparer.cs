using System;

namespace Comparers
{
   
    public class StringByLengthComparer<T>
    {
        public int Compare<T>(T x, T y) 
        {
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x is string a && y is string b)
            {
                return a.Length.CompareTo(b.Length);
            }
            if (x is int c && y is int d)
            {
                return Math.Abs(c).CompareTo(Math.Abs(d));
            }

            return 1;
        }
    }
}