using System;

namespace Comparers
{
   
    public class StringByLengthComparer<T>
    {
        public int Compare<T>(T x, T y) 
        {
            if(x is string a && y is string b)
            {
                if (string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
                    return -1;
                if (!string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                    return 1;
                if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                    return 0;
                return a.Length.CompareTo(b.Length);
            }
            if (x is int c && y is int d)
            {
                return Math.Abs(c).CompareTo(Math.Abs(d));
            }

            return -1;
        }
    }
}