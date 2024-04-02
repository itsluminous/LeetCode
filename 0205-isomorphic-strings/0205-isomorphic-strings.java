public class Solution {
    public boolean isIsomorphic(String s, String t) {
        if(s.length() != t.length()) return false;
        char[] sarr = s.toCharArray(), tarr = t.toCharArray();
        int[] sval = new int[256], tval = new int[256];

        for(var i=0; i<s.length(); i++){
            var sch = sarr[i];
            var tch = tarr[i];
            if(sval[sch] != tval[tch]) return false;
            sval[sch] = tval[tch] = i+1;
        }
        return true;
    }
}