class Solution {
    public boolean hasSpecialSubstring(String s, int k) {
        var count = 1;
        for(var i=1; i<s.length(); i++){
            if(s.charAt(i) == s.charAt(i-1)) 
                count++;
            else if(count == k)
                return true;
            else 
                count = 1;
        }

        return count == k;
    }
}