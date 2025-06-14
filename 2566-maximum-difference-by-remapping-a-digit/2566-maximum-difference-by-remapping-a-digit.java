class Solution {
    public int minMaxDifference(int num) {
        // for 5 digit number like 11891, divisor should be 10000
        var digits = (int) Math.floor(Math.log10(num)); // it will give one less count
        var divisor = (int)Math.pow(10, digits);

        int minNum = 0, maxNum = 0;
        int minReplace = -1, maxReplace = -1;   // digit that needs to be replaced with 0 (for min) or 9 (for max)
        
        while(divisor >= 1){
            var digit = num / divisor;
            num %= divisor;
            if(divisor == 1) divisor = -1;  // we don't want next loop to run
            else divisor /= 10;

            // figure out if this digit should be replaced
            if(digit > 0 && minReplace == -1) minReplace = digit;
            if(digit < 9 && maxReplace == -1) maxReplace = digit;

            // if applicable, replace this digit in minNum
            if(digit == minReplace) minNum = minNum * 10 + 0;
            else minNum = minNum * 10 + digit;

            // if applicable, replace this digit in maxNum
            if(digit == maxReplace) maxNum = maxNum * 10 + 9;
            else maxNum = maxNum * 10 + digit;
        }

        return maxNum - minNum;
    }
}