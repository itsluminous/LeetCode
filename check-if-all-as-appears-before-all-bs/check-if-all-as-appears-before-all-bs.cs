public class Solution {
    public bool CheckString(string s) {
        var bFound = false;
        foreach(var ch in s){
            if(bFound && ch=='a') return false;
            else if(ch=='b') bFound = true;
        }
        return true;
    }
}