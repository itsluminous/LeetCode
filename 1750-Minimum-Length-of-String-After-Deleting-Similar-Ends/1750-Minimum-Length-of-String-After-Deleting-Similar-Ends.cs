public class Solution {
    public int MinimumLength(string s) {
        int n = s.Length, l=0, r=n-1;
        if(l == r) return 1;    // only one char in string

        while(l<r){
            if(s[l] != s[r]) break;
            var ch = s[l];
            while(l<=r && s[l] == ch) l++;
            while(l<=r && s[r] == ch) r--;
        }
        if(l>r) return 0;   // can happen only when last elimination was for same char, and nothing is left
        return r-l+1;
    }
}