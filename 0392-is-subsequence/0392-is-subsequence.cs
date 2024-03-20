public class Solution {
    public bool IsSubsequence(string s, string t) {
        int sidx = 0, tidx = 0;
        while(sidx < s.Length && tidx < t.Length){
            if(s[sidx] == t[tidx])
                sidx++;
            tidx++;
        }
        if(sidx == s.Length) return true;
        return false;
    }
}