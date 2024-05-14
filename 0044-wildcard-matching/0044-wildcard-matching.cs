public class Solution {
    int[,] dp;

    public bool IsMatch(string s, string p) {
        if(s.Length == 0 && p.Length == 0) return true;

        dp = new int[s.Length, p.Length];
        for(var i=0; i<s.Length; i++)
            for(var j=0; j<p.Length; j++)
                dp[i,j] = -1;

        return IsMatch(s, p, 0, 0) == 1;
    }

    public int IsMatch(string s, string p, int sIdx, int pIdx) {
        if(sIdx == s.Length && pIdx == p.Length) return 1;      // found perfect match
        if(sIdx == s.Length && pIdx != p.Length && AllStarsInP(p, pIdx)) return 1;  // pattern like '****'
        if(sIdx == s.Length || pIdx == p.Length) return 0;      // will never match in this case
        
        if(dp[sIdx, pIdx] != -1) return dp[sIdx, pIdx];         // already processed

        if(s[sIdx] == p[pIdx]) dp[sIdx, pIdx] = IsMatch(s, p, sIdx+1, pIdx+1);      // exact alphabet match
        else if(p[pIdx] == '?') dp[sIdx, pIdx] = IsMatch(s, p, sIdx+1, pIdx+1);     // '?' matches alphabet
        
        else if(p[pIdx] == '*'){
            dp[sIdx, pIdx] = IsMatch(s, p, sIdx, pIdx+1);               // don't match with anything
            if(dp[sIdx, pIdx] != 1)
                dp[sIdx, pIdx] = IsMatch(s, p, sIdx+1, pIdx+1);         // match with exactly one char
            if(dp[sIdx, pIdx] != 1)
                dp[sIdx, pIdx] = IsMatch(s, p, sIdx+1, pIdx);           // match with more than one char
        }
        else dp[sIdx, pIdx] = 0;                // not possible to match

        return dp[sIdx, pIdx];
    }

    private bool AllStarsInP(string p, int pIdx){
        for(var i=pIdx; i<p.Length; i++)
            if(p[i] != '*') return false;
        return true;
    }
}