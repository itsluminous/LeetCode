// Bob can only win if total count of vowels is 0
public class Solution {
    public bool DoesAliceWin(string s) {
        foreach(var ch in s)
            if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                return true;
        return false;
    }
}