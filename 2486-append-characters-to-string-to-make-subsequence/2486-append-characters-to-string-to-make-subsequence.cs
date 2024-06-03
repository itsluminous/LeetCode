public class Solution {
    public int AppendCharacters(string s, string t) {
        int tIdx = 0, tLen = t.Length;

        for(var sIdx = 0; sIdx < s.Length && tIdx < tLen; sIdx++){
            if(t[tIdx] == s[sIdx])
                tIdx++;
        }

        return tLen - tIdx;
    }
}