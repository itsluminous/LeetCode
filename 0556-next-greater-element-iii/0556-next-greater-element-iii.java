class Solution {
    public int nextGreaterElement(int n) {
        if(n < 10) return -1;   // single digit

        long mul = 100;         // multiplier
        var prev = n % 10;      // last digit
        n /= 10;
        
        var digits = new ArrayList<Integer>();
        digits.add(prev);

        // while n is 2 or more digit
        while(n > 9){
            var curr = n % 10;
            n /= 10;
            var newNum = tryMakeNewNum(n, mul, curr, prev, digits);
            if(newNum != -1) return newNum;

            digits.add(curr);
            prev = curr;
            mul *= 10;
        }

        return tryMakeNewNum(0, mul, n, prev, digits);
    }

    private int tryMakeNewNum(int fixedPart, long mul, int curr, int prev, List<Integer> digits){
        if(curr >= prev) return -1;     // not possible to make bigger number
        
        // find index of number just greater than curr
        Collections.sort(digits);
        var idx = 0;
        while(idx < digits.size() && digits.get(idx) <= curr) idx++;
        if(idx == digits.size()) return -1;

        var newDigit = digits.get(idx);
        digits.set(idx, curr);
        long nextGreater = makeNum(fixedPart, newDigit, digits, mul);
        if(nextGreater <= Integer.MAX_VALUE)
            return (int)nextGreater;

        return -1;
    }

    private long makeNum(int n1, int n2, List<Integer> digits, long mul){
        long newNum = n1 * mul; 

        mul /= 10;
        newNum += n2 * mul;

        mul /= 10;
        for(var digit : digits){
            newNum += digit * mul;
            mul /= 10;
        }

        return newNum;
    }
}