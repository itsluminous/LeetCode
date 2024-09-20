public class Solution {
    public string ShortestPalindrome(string s) {
        var reverse = new string(s.Reverse().ToArray());
        var combined = s + "#" + reverse;
        var lps = ComputeLPS(combined);

        var unmatchStrLen = s.Length - lps[combined.Length - 1];
        var newStr = reverse.Substring(0, unmatchStrLen);
        return newStr + s;
    }

    private int[] ComputeLPS(string s){
        var n = s.Length;
        var lps = new int[n];
        int len = 0, i = 1; // len is the current longest prefix suffix and i is curr index in pattern

        while(i < n){
            if(s[i] == s[len]){
                len++;
                lps[i] = len;
                i++;
            }
            // two possibilities when there is no match
            else if(len == 0){
                lps[i] = len;   // basically, lps[i] is set to 0
                i++;
            }
            else
                len = lps[len-1];
        }

        return lps;
    }
}