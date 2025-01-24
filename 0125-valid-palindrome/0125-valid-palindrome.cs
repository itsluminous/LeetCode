public class Solution {
    public bool IsPalindrome(string s) {
        var n = s.Length;
        for(int i=0, j=n-1; i <= j; i++, j--){
            while(i < n && !char.IsLetterOrDigit(s[i])) i++;
            while(j >= 0 && !char.IsLetterOrDigit(s[j])) j--;
            if(i == n || j == -1) return true;
            if(char.ToLower(s[i]) != char.ToLower(s[j])) return false;
        }
        return true;
    }
}