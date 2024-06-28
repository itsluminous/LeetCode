// loop through string, and for each index, expand around it
class Solution {
    int maxLen = 1;
    int maxStart = 0;

    public String longestPalindrome(String s) {
        if(s.length() < 2) return s;

        for(var i=0; i<s.length(); i++){
            expandFromCenter(s, i, i);      // odd length palindrome
            expandFromCenter(s, i, i+1);    // even length palindrome
        }

        return s.substring(maxStart, maxStart + maxLen);
    }

    private void expandFromCenter(String s, int l, int r){
        while(l >= 0 && r < s.length() && (s.charAt(l) == s.charAt(r))){
            l--;
            r++;
        }

        if(r - l - 1 > maxLen) {
            maxLen = r - l - 1;
            maxStart = l+1;
        }
    }
}

// Accepted - DP
// we crate a 2d boolean matrix of string length
// any index i,j in matrix tells if string between index i and j (inclusive) is palindrome or not
// video link : https://www.youtube.com/watch?v=UflHuQj6MVA
class SolutionDP {
    public String longestPalindrome(String s) {
        var n = s.length();
        if(n < 2) return s;

        int maxLen = 1, maxStart = 0;
        var dp = new boolean[n][n];

        for(var r=0; r<n; r++){
            dp[r][r] = true;    // a single character is always palindrome

            for(var l=0; l<r; l++){
                // two chars at border are equal  &&  (only <= two chars are present OR all chars in between are palindrome)
                if(s.charAt(r) == s.charAt(l) && (r - l <= 2 || dp[l+1][r-1])){
                    dp[l][r] = true;
                    if(r - l + 1 > maxLen){
                        maxLen = r - l + 1;
                        maxStart = l;
                    }
                }
            }
        }

        return s.substring(maxStart, maxStart + maxLen);
    }
}