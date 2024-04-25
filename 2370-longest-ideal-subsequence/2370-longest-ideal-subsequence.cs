public class Solution {
    public int LongestIdealString(string s, int k) {
        var dp = new int[26];   // to count the max subsequence for every char, from right
        int n = s.Length, ans = 1;

        for(var i=n-1; i>=0; i--){
            var ch = s[i];
            // the "ch" can only allow chars on left side of alphabet with diff <= k or right side with diff >= k
            var smallest = Math.Max(0, (ch-'a')-k);
            var largest = Math.Min(25, (ch-'a')+k);
            
            var max = 0;
            for(var j=smallest; j<=largest; j++)
                max = Math.Max(max, dp[j]);

            dp[ch-'a'] = 1 + max;
            ans = Math.Max(ans, dp[ch-'a']);
        }

        return ans;
    }
}