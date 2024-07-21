// Bob can only win if total count of vowels is 0
class Solution {
    public boolean doesAliceWin(String s) {
        for(var ch : s.toCharArray())
            if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                return true;
        return false;
    }
}