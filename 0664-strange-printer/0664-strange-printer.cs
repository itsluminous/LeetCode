public class Solution {
    public int StrangePrinter(string s) {
        // remove consecutive same chars
        var sb = new StringBuilder();
        sb.Append(s[0]);
        for(var i=1; i<s.Length; i++)
            if(s[i] != s[i-1])
                sb.Append(s[i]);
        s = sb.ToString();

        // build dp array. turns needed from idx i to j = dp[i,j]
        var n = s.Length;
        var dp = new int[n,n];
        for(var i=0; i<n-1; i++){
            dp[i,i] = 1;   // one char only, so only 1 turn needed
            dp[i,i+1] = 2; // the adjacent chars will definitely be different (we removed consecutive same chars)
        }
        dp[n-1,n-1] = 1;

        // fill dp array
        for(var len=2; len<n; len++){
            for(var start=0; start+len < n; start++){
                dp[start,start+len] = len + 1; // worst case - all chars are different
                
                // try to split this string of size len in two parts at different indexes
                for(var k=0; k<len; k++){
                    var turn = dp[start,start+k] + dp[start+k+1,start+len];
                    // if any char matches last char, they can be printed in 1 turn
                    if(s[start+k] == s[start+len]) turn--;
                    dp[start,start+len] = Math.Min(dp[start,start+len], turn);
                }
            }
        }

        // count of ops for entire string, i.e. starting from 0 and ending at n-1
        return dp[0,n-1];
    }
}