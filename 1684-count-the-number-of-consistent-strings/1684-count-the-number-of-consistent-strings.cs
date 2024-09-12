public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        var letters = new bool[26];
        foreach(var ch in allowed)
            letters[ch - 'a'] = true;
        
        var consistent = 0;
        foreach(var word in words){
            consistent++;
            foreach(var ch in word){
                if(!letters[ch - 'a']){
                    consistent--;
                    break;
                }
            }
        }

        return consistent;
    }
}