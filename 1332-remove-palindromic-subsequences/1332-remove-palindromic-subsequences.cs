public class Solution {
    public int RemovePalindromeSub(string s) {
        // if string is not palindrome, remove all 'a' in 1 operation, then all 'b'
        for(int i=0, j=s.Length-1; i<j; i++,j--)
            if(s[i] != s[j])
                return 2;
        
        // if string is palindrome
        return 1;
    }
}