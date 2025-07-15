public class Solution {
    public bool IsValid(string word) {
        if(word.Length < 3) return false;
        
        HashSet<char> vowels = new HashSet<char>{'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        bool vowel = false, consonant = false;
        foreach(var ch in word){
            if(ch < '0' || (ch > '9' && ch < 'A') || (ch > 'Z' && ch < 'a') || ch > 'z') return false;
            if(vowels.Contains(ch)) vowel = true;
            else if(ch > '9') consonant = true;
        }
        
        return vowel && consonant;
    }
}