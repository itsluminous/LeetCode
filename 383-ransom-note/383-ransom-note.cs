public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var chars = new int[26];
        foreach(var ch in magazine)
            chars[ch-'a']++;
        
        foreach(var ch in ransomNote){
            if(chars[ch-'a'] == 0) return false;
            else chars[ch-'a']--;
        }
        return true;
    }
}