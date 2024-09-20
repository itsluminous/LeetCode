class Solution {
    public String shortestPalindrome(String s) {
        var reverse = new StringBuilder(s).reverse().toString();
        var combined = s + "#" + reverse;
        var lps = computeLPS(combined.toCharArray());

        var unmatchStrLen = s.length() - lps[combined.length() - 1];
        var newStr = reverse.substring(0, unmatchStrLen);
        return newStr + s;
    }

    private int[] computeLPS(char[] s){
        var n = s.length;
        var lps = new int[n];
        int len=0, i=1;     // len is the current longest prefix suffix and i is curr index in pattern
        
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