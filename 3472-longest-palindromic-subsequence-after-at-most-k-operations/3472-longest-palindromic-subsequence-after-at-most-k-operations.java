class Solution {
    public int longestPalindromicSubsequence(String s, int k) {
        var n = s.length();
        
        // dp to cache length for str starting i, ending j, with k ops
        var dp = new int[n][n][k+1];    
        for(var i = 0; i < n; i++)
            for(var j = 0; j < n; j++)
                for(var l = 0; l <= k; l++)
                    dp[i][j][l] = -1;

        return longestPalindrome(s, 0, n-1, k, dp);
    }

    private int longestPalindrome(String s, int i, int j, int k, int[][][] dp) {
        if(i > j) return 0;
        if(dp[i][j][k] != -1) return dp[i][j][k];
        if(i == j) return 1;

        var ans = 0;
        
        // no operation needed
        if(s.charAt(i) == s.charAt(j))
            ans = 2 + longestPalindrome(s, i+1, j-1, k, dp);
        else {
            var cost = getChangeCost(s.charAt(i), s.charAt(j));
            int option1 = 0, option2 = 0, option3 = 0;

            // option 1 : change both the chars to match
            if(k >= cost) option1 = 2 + longestPalindrome(s, i+1, j-1, k - cost, dp);
            // option 2 : skip char at i
            option2 = longestPalindrome(s, i+1, j, k, dp);
            // option 3 : skip char at j
            option3 = longestPalindrome(s, i, j-1, k, dp);

            ans = Math.max(option1, Math.max(option2, option3));
        }

        dp[i][j][k] = ans;
        return ans;
    }

    private int getChangeCost(char ch1, char ch2) {
        var pos1 = ch1 - 'a';
        var pos2 = ch2 - 'a';
        var forward = (pos2 - pos1 + 26) % 26;
        var backward = (pos1 - pos2 + 26) % 26;
        return Math.min(forward, backward);
    }
}