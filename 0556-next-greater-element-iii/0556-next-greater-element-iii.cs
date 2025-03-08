public class Solution {
    public int NextGreaterElement(int n) {
        if(n < 10) return -1;   // single digit

        long mul = 100;         // multiplier
        var prev = n % 10;      // last digit
        n /= 10;
        
        var digits = new List<int>();
        digits.Add(prev);

        // while n is 2 or more digit
        while(n > 9){
            var curr = n % 10;
            n /= 10;
            var newNum = TryMakeNewNum(n, mul, curr, prev, digits);
            if(newNum != -1) return newNum;

            digits.Add(curr);
            prev = curr;
            mul *= 10;
        }

        return TryMakeNewNum(0, mul, n, prev, digits);
    }

    private int TryMakeNewNum(int fixedPart, long mul, int curr, int prev, List<int> digits){
        if(curr >= prev) return -1;     // not possible to make bigger number
        
        // find index of number just greater than curr
        digits.Sort();
        var idx = 0;
        while(idx < digits.Count && digits[idx] <= curr) idx++;
        if(idx == digits.Count) return -1;

        var newDigit = digits[idx];
        digits[idx] = curr;
        long nextGreater = MakeNum(fixedPart, newDigit, digits, mul);
        if(nextGreater <= int.MaxValue)
            return (int)nextGreater;

        return -1;
    }

    private long MakeNum(int n1, int n2, List<int> digits, long mul){
        long newNum = n1 * mul; 

        mul /= 10;
        newNum += n2 * mul;

        mul /= 10;
        foreach(var digit in digits){
            newNum += digit * mul;
            mul /= 10;
        }

        return newNum;
    }
}