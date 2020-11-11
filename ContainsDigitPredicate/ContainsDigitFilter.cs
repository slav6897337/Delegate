using System;

namespace ContainsDigitPredicate
{
    public class ContainsDigitValidator
    {  
        private int digit;

        public int Digit
        {
            get => digit;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{value} Expected digit cannot be less than zero.");
                }

                if (value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{value} Expected digit cannot be out of range 0..9.");
                }

                digit = value;
            }
        }
        public bool Verify(int val)
        {
            if (val == 0 && Digit == 0)
            {
                return true;
            }

            int temp;
            if (val == int.MinValue)
            {
                temp = int.MaxValue;
            }
            else
            {
                temp = Math.Abs(val);
            }

            while (temp / 10 > 0 || temp % 10 > 0)
            {
                int res;
                temp = Math.DivRem(temp, 10, out res);

                if (res == Digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}