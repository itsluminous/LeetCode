public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        
        var chars = new int[26];
        foreach(var ch in s) chars[ch-'a']++;
        foreach(var ch in t) chars[ch-'a']--;
        foreach(var num in chars) if(num != 0) return false;
        
        return true;
    }
}