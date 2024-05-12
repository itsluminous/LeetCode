// similar : https://leetcode.com/problems/number-of-subarrays-that-match-a-pattern-ii/
class Solution {
    public int strStr(String haystack, String needle) {
        if(needle.length() > haystack.length()) return -1;

        var lps = computeLPS(needle);
        return kmpSearch(haystack, needle, lps);
    }

    private int[] computeLPS(String needle){
        var n = needle.length();
        var lps = new int[n];
        int len=0, i=1;

        while(i < n){
            if(needle.charAt(i) == needle.charAt(len)){
                len++;
                lps[i] = len;
                i++;
            }
            else if(len == 0){
                lps[i] = 0;
                i++;
            }
            else
                len = lps[len-1];
        }

        return lps;
    }

    private int kmpSearch(String haystack, String needle, int[] lps){
        int hLen = haystack.length(), nLen = needle.length();
        int hIdx = 0, nIdx = 0;

        while(hIdx < hLen){
            if(haystack.charAt(hIdx) == needle.charAt(nIdx)){
                hIdx++;
                nIdx++;
            }
            
            if(nIdx == nLen) return hIdx - nLen;    // found full match
            if(hIdx < hLen && haystack.charAt(hIdx) != needle.charAt(nIdx)){
                if(nIdx != 0) nIdx = lps[nIdx-1];
                else hIdx++;
            }
        }

        return -1;
    }
}