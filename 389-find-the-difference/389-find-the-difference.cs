// using XOR
public class Solution {
    public char FindTheDifference(string s, string t) {
        int result = 0, n = s.Length;
        for(var i=0; i<n; i++){
            result ^= s[i];
            result ^= t[i];
        }
        result ^= t[n];
        
        return (char)result;
    }
}

// Accepted - using array
public class Solution1 {
    public char FindTheDifference(string s, string t) {
        var letters = new int[26];
        foreach(var ch in s)
            letters[ch-'a']++;
        
        foreach(var ch in t){
            if(letters[ch-'a'] == 0) return ch;
            letters[ch-'a']--;
        }
        return t[0];
    }
}