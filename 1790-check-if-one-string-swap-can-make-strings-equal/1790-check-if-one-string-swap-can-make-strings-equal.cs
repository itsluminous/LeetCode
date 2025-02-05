public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        var idx = -1;   // index of first mismatch
        
        for(var i=0; i<s1.Length; i++){
            if(s1[i] == s2[i]) continue;
            if(idx == -2) return false; // 1 swap was already done
            if(idx == -1) idx = i;      // first mismatch
            else if(s1[idx] != s2[i] || s1[i] != s2[idx]) return false;  // swapping won't help
            else idx = -2;
        }

        return idx < 0;
    }
}