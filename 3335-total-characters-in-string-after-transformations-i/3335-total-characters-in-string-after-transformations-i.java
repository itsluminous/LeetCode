class Solution {
    int MOD = 1_000_000_007;

    public int lengthAfterTransformations(String s, int t) {
        var ans = 0;
        var dp = lengthAfterNTransformations();

        for(var ch : s.toCharArray()){
            var idx = ch - 'a' + t;
            ans = (ans + dp[idx]) % MOD;
        }

        return ans;
    }

    // function to find length of "a" after N transformations
    private int[] lengthAfterNTransformations(){
        var n = 100026; // total 10^5 transformations are allowed, so 10^5 + 26 (buffer)
        var dp = new int[n];
        for(var i=0; i<n; i++){
            if(i < 26) dp[i] = 1;   // length will be 1 till z (because transformation has not happened)
            else dp[i] = (dp[i-26] + dp[i-25]) % MOD;   // 26 steps to double from a, 25 from b
        }
        return dp;
    }
}