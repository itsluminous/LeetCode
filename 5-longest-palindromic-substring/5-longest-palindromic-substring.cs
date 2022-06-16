public class Solution {
    public string LongestPalindrome(string s) {
        // we crate a 2d boolean matrix of string length
        // any index i,j in matrix tells if string between index i and j (inclusive) is palindrome or not
        // video link : https://www.youtube.com/watch?v=UflHuQj6MVA
        var n = s.Length;
        var matrix = new bool[n,n];
        var maxLen = 1;
        var startIdx = 0;
        
        // fill up the diagonal as all single characters are always palindrome
        for(int i=0; i<n; i++)
            matrix[i,i] = true;
        
        // fill up the matrix for all possible 2 letter words
        for(int i=0; i<n-1; i++){
            if(s[i] == s[i+1]){
                matrix[i,i+1] = true;
                maxLen = 2;
                startIdx = i;
            }
        }
        
        // now fill up matrix for all possible words with >= 3 letters
        for(int len = 3; len<=n; len++){
            for(int i=0; i<=n-len; i++){
                var j = i+len-1;    //last char in <len> letter word
                //if first and last are same char, and word between them is palindrome
                if(s[i] == s[j] && matrix[i+1,j-1]){
                    matrix[i,j] = true;
                    maxLen = Math.Max(maxLen, len);
                    startIdx = i;
                }
            }
        }
        
        return s.Substring(startIdx, maxLen);
    }
}