public class Solution {
    public bool IsSubsequence(string s, string t) {
        int sIdx = 0, tIdx = 0, sLen = s.Length, tLen = t.Length;
        if(sLen == 0) return true;
        
        while(tIdx < tLen){
            if(s[sIdx] == t[tIdx++]) sIdx++;
            if(sIdx == sLen) return true;
        }
        
        return false;
    }
}