// Idea is that for each character, expand on both sides
public class Solution {
    public int CountSubstrings(string s) {
        var count = 0;
        for(var i=0; i<s.Length; i++){
            count += CountPallindromes(s, i, i);    // odd length
            count += CountPallindromes(s, i, i+1);  // even length
        }
        return count;
    }
    
    private int CountPallindromes(string s, int left, int right){
        var count = 0;
        while(left >=0 && right < s.Length && s[left] == s[right]){
            count++;
            left--;
            right++;
        }
        return count;
    }
}