// Accepted - using an extra array space
public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        var nString = n.ToString();
        int nLen = nString.Length, digitsLen = digits.Length;
        var dp = new double[nLen + 1];  // it tells number of possible digits at i-th location
        dp[nLen] = 1;

        // find out possibilities in case of numbers with same count of digit
        for(var i=nLen-1; i>=0; i--){   // for each position in number
            var maxPossible = nString[i] - '0';
            foreach(var digit in digits){
                // in this case next digits can be anything from array
                if(int.Parse(digit) < maxPossible)
                    dp[i] += Math.Pow(digitsLen, nLen-i-1);
                //in this case next digit can be only less than or equal to maxPossible
                else if(int.Parse(digit) == maxPossible)
                    dp[i] += dp[i+1];
            }
        }

        // any number having less digits than n will be valid
        for(var i=1; i<nLen; i++)
            dp[0] += Math.Pow(digitsLen, i);


        // convert double to int
        return Convert.ToInt32(dp[0]);
    }
}

// without using extra space
public class Solution1 {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        var nString = n.ToString();
        int nLen = nString.Length, digitsLen = digits.Length;
        double count = 0; 
        
        // any number having less digits than n will be valid
        for(var i=1; i<nLen; i++)
            count += Math.Pow(digitsLen, i);

        // find out possibilities in case of numbers with same count of digit
        for(var i=0; i<nLen; i++){   // for each position in number
            var maxPossible = nString[i] - '0';
            var hasSameNum = false;
            foreach(var digit in digits){
                // in this case next digits can be anything from array
                if(int.Parse(digit) < maxPossible)
                    count += Math.Pow(digitsLen, nLen-i-1);
                //in this case next digit can be only less than or equal to maxPossible
                else if(int.Parse(digit) == maxPossible)
                    hasSameNum = true;
            }
            if (!hasSameNum)
                return Convert.ToInt32(count);
        }
        return Convert.ToInt32(count+1);    // +1 because last num will be exact same num as n. so we add one possibility for it
    }
}