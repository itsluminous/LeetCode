public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int s1len = s1.Length, s2len = s2.Length;
        if(s1len > s2len) return false;
        
        int[] s1chars = new int[26], s2chars = new int[26];
        for(var i=0; i<s1len; i++){
            s1chars[s1[i]-'a']++;
            s2chars[s2[i]-'a']++;
        }
        
        for(int i=0; i<s2len - s1len; i++){
            if(checkPermutation(s2chars, s1chars)) return true;
            s2chars[s2[i] - 'a']--;
            s2chars[s2[i+s1len] - 'a']++;
        }
        return checkPermutation(s2chars, s1chars);
    }
    
    private bool checkPermutation(int[] s2chars, int[] s1chars){
        for(int i=0; i<s2chars.Length; i++){
            if(s2chars[i] != s1chars[i]) return false;
        }
        return true;
    }
}