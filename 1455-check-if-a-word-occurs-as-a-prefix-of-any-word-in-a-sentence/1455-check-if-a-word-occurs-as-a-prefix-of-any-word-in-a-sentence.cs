public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        var words = sentence.Split();
        for(var i=0; i<words.Length; i++){
            if(words[i].StartsWith(searchWord))
                return i+1;
        }
        return -1;
    }
}