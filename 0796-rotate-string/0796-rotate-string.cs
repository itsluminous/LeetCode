public class Solution {
    public bool RotateString(string s, string goal) {
        if(s.Length != goal.Length) return false;

        s += s;
        return s.IndexOf(goal) >= 0;
    }
}

public class SolutionKMP {
    public bool RotateString(string s, string goal) {
        if(s.Length != goal.Length) return false;

        var lps = ComputeLPS(goal);
        return KMPSearch(s+s, goal, lps);
    }

    private int[] ComputeLPS(string goal){
        var n = goal.Length;
        var lps = new int[n];
        int len=0, i=1;

        while(i < n){
            if(goal[i] == goal[len]){
                len++;
                lps[i++] = len;
            }
            else if(len == 0)
                lps[i++] = 0;
            else
                len = lps[len-1];
        }

        return lps;
    }

    private bool KMPSearch(string s, string goal, int[] lps){
        int sLen = s.Length, gLen = goal.Length;
        int sIdx = 0, gIdx = 0;

        while(sIdx < sLen){
            if(s[sIdx] == goal[gIdx]){
                sIdx++;
                gIdx++;
            }

            if(gIdx == gLen) return true;   // found complete match
            if(sIdx < sLen && s[sIdx] != goal[gIdx]){
                if(gIdx != 0) gIdx = lps[gIdx-1];
                else sIdx++;
            }
        }
        return false;
    }
}