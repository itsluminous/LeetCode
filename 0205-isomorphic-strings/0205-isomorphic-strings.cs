public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s.Length != t.Length) return false;
        int[] sval = new int[256], tval = new int[256];

        for(var i=0; i<s.Length; i++){
            var (sch, tch) = (s[i], t[i]);
            if(sval[sch] != tval[tch]) return false;
            sval[sch] = tval[tch] = i+1;
        }
        return true;
    }
}