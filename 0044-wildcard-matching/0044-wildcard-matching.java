class Solution {
    int[][] dp;

    public boolean isMatch(String s, String p) {
        if(s.length() == 0 && p.length() == 0) return true;

        dp = new int[s.length()][p.length()];
        for(var i=0; i<s.length(); i++)
            for(var j=0; j<p.length(); j++)
                dp[i][j] = -1;

        return isMatch(s.toCharArray(), p.toCharArray(), 0, 0) == 1;
    }

    private int isMatch(char[] s, char[] p, int sIdx, int pIdx) {
        if(sIdx == s.length && pIdx == p.length) return 1;      // found perfect match
        if(sIdx == s.length && pIdx != p.length && allStarsInP(p, pIdx)) return 1;  // pattern like '****'
        if(sIdx == s.length || pIdx == p.length) return 0;      // will never match in this case
        
        if(dp[sIdx][pIdx] != -1) return dp[sIdx][pIdx];         // already processed

        if(s[sIdx] == p[pIdx]) dp[sIdx][pIdx] = isMatch(s, p, sIdx+1, pIdx+1);      // exact alphabet match
        else if(p[pIdx] == '?') dp[sIdx][pIdx] = isMatch(s, p, sIdx+1, pIdx+1);     // '?' matches alphabet
        
        else if(p[pIdx] == '*'){
            dp[sIdx][pIdx] = isMatch(s, p, sIdx, pIdx+1);               // don't match with anything
            if(dp[sIdx][pIdx] != 1)
                dp[sIdx][pIdx] = isMatch(s, p, sIdx+1, pIdx+1);         // match with exactly one char
            if(dp[sIdx][pIdx] != 1)
                dp[sIdx][pIdx] = isMatch(s, p, sIdx+1, pIdx);           // match with more than one char
        }
        else dp[sIdx][pIdx] = 0;                // not possible to match

        return dp[sIdx][pIdx];
    }

    private boolean allStarsInP(char[] p, int pIdx){
        for(var i=pIdx; i<p.length; i++)
            if(p[i] != '*') return false;
        return true;
    }
}