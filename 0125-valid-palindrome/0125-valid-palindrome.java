class Solution {
    public boolean isPalindrome(String s) {
        var n = s.length();
        for(int i=0, j=n-1; i <= j; i++, j--){
            while(i < n && !Character.isLetterOrDigit(s.charAt(i))) i++;
            while(j >= 0 && !Character.isLetterOrDigit(s.charAt(j))) j--;
            if(i == n || j == -1) return true;
            if(Character.toLowerCase(s.charAt(i)) != Character.toLowerCase(s.charAt(j))) return false;
        }
        return true;
    }
}