// Using bitwise operation
public class Solution {
    public bool IsPowerOfTwo(int n) {
        if(n < 2) return n == 1;
        // Power of 2 means only one bit of n is '1', so use the trick n&(n-1)==0 to test
        return ((n & n-1) == 0);
    }
}

// using logarithm
// can't use simple divide because of issue with division in double time
// eg. n = 536870912 OR 524287
public class SolutionLog {
    public bool IsPowerOfTwo(int n) {
        var pow = Math.Log(n) / Math.Log(2);
        var str = pow.ToString("F5");
        var dec = decimal.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine($"pow={pow}, str={str}, dec={dec}");
        return Math.Ceiling(dec) == Math.Floor(dec);
    }
}