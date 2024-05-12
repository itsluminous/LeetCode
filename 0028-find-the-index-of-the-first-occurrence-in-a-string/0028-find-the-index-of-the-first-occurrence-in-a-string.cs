// similar : https://leetcode.com/problems/number-of-subarrays-that-match-a-pattern-ii/
public class Solution {
    public int StrStr(string haystack, string needle) {
        if(needle.Length > haystack.Length) return -1;

        var lps = ComputeLPS(needle);
        return KMPSearch(haystack, needle, lps);
    }

    private int[] ComputeLPS(string needle){
        var n = needle.Length;
        var lps = new int[n];
        int len=0, i=1;

        while(i < n){
            if(needle[i] == needle[len]){
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

    private int KMPSearch(string haystack, string needle, int[] lps){
        int hLen = haystack.Length, nLen = needle.Length;
        int hIdx = 0, nIdx = 0;

        while(hIdx < hLen){
            if(haystack[hIdx] == needle[nIdx]){
                hIdx++;
                nIdx++;
            }
            
            if(nIdx == nLen) return hIdx - nLen;    // found full match
            if(hIdx < hLen && haystack[hIdx] != needle[nIdx]){
                if(nIdx != 0) nIdx = lps[nIdx-1];
                else hIdx++;
            }
        }

        return -1;
    }
}