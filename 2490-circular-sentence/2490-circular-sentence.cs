public class Solution {
    public bool IsCircularSentence(string sentence) {
        var words = sentence.Split(' ');
        if(words[^1][^1] != words[0][0]) return false;

        for(var i=1; i<words.Length; i++)
            if(words[i][0] != words[i-1][^1]) return false;
        return true;
    }
}