class Solution {
    public int appendCharacters(String s, String t) {
        int tIdx = 0, tLen = t.length();

        for(var sIdx = 0; sIdx < s.length() && tIdx < tLen; sIdx++){
            if(t.charAt(tIdx) == s.charAt(sIdx))
                tIdx++;
        }

        return tLen - tIdx;
    }
}