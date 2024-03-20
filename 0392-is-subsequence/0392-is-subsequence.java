class Solution {
    public boolean isSubsequence(String s, String t) {
        int sidx = 0, tidx = 0;
        char[] sch = s.toCharArray(), tch = t.toCharArray();
        while(sidx < sch.length && tidx < tch.length){
            if(sch[sidx] == tch[tidx])
                sidx++;
            tidx++;
        }
        if(sidx == s.length()) return true;
        return false;
    }
}