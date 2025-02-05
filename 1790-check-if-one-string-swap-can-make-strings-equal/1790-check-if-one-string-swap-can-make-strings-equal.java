class Solution {
    public boolean areAlmostEqual(String s1, String s2) {
        var idx = -1;   // index of first mismatch
        
        for(var i=0; i<s1.length(); i++){
            if(s1.charAt(i) == s2.charAt(i)) continue;
            if(idx == -2) return false; // 1 swap was already done
            if(idx == -1) idx = i;      // first mismatch
            else if(s1.charAt(idx) != s2.charAt(i) || s1.charAt(i) != s2.charAt(idx)) return false;  // swapping won't help
            else idx = -2;
        }

        return idx < 0;
    }
}