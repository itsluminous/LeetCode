public class Solution
    {
        private const int MODULO = 1_000_000_007;

        private long GreatestCommonDivisor(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }
            return GreatestCommonDivisor(b % a, a);
        }

        private long LowestCommonMultiple(long a, long b)
        {
            return (a * b) / GreatestCommonDivisor(a, b);
        }

        public int NthMagicalNumber(int n, int a, int b)
        {
            checked
            {
                long smm = LowestCommonMultiple(a, b);
                long left = 1;
                long right = long.MaxValue;

                long CalculateCount(long mid)
                {
                    long count = 0;
                    count += mid / a;
                    count += mid / b;
                    count -= mid / smm;
                    return count;
                }

                while (left < right)
                {
                    if (right - left <= 1)
                    {
                        break;
                    }

                    long mid = left + (right - left) / 2;
                    long count = CalculateCount(mid);

                    if (count >= n)
                    {
                        right = mid;
                        continue;
                    }

                    left = mid;
                }

                if (CalculateCount(left) == n)
                {
                    return (int)(left % MODULO);
                }

                return (int)(right % MODULO);
            }
        }
    }