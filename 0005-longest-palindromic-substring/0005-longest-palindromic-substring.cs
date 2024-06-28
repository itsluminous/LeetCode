// loop through string, and for each index, expand around it
public class Solution {
    int maxLen = 1;
    int maxStart = 0;

    public string LongestPalindrome(string s) {
        if(s.Length < 2) return s;

        for(var i=0; i<s.Length; i++){
            ExpandFromCenter(s, i, i);      // odd length palindrome
            ExpandFromCenter(s, i, i+1);    // even length palindrome
        }

        return s.Substring(maxStart, maxLen);
    }

    private void ExpandFromCenter(string s, int l, int r){
        while(l >= 0 && r < s.Length && (s[l] == s[r])){
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
public class SolutionDP {
    public string LongestPalindrome(string s) {
        var n = s.Length;
        if(n < 2) return s;

        int maxLen = 1, maxStart = 0;
        var dp = new bool[n,n];

        for(var r=0; r<n; r++){
            dp[r,r] = true;    // a single character is always palindrome

            for(var l=0; l<r; l++){
                // two chars at border are equal  &&  (only <= two chars are present OR all chars in between are palindrome)
                if(s[r] == s[l] && (r - l <= 2 || dp[l+1,r-1])){
                    dp[l,r] = true;
                    if(r - l + 1 > maxLen){
                        maxLen = r - l + 1;
                        maxStart = l;
                    }
                }
            }
        }

        return s.Substring(maxStart, maxLen);
    }
}