public class Solution {
    public bool HasSpecialSubstring(string s, int k) {
        var count = 1;
        for(var i=1; i<s.Length; i++){
            if(s[i] == s[i-1]) 
                count++;
            else if(count == k)
                return true;
            else 
                count = 1;
        }

        return count == k;
    }
}