public class Solution {
    public string AnswerString(string word, int numFriends) {
        if(numFriends == 1) return word;
        
        var len = word.Length;
        var maxLen = len-numFriends+1;  // max length of ans
        
        // check all strings of size maxLen
        var largest = word.Substring(0, maxLen);
        for(var i=1; i+maxLen<=len; i++){
            var currWord = word.Substring(i, maxLen);
            if(string.Compare(currWord, largest) > 0)
                largest = currWord;
        }

        // try all remaining chars at end (of size < maxLen)
        for(var i=len-maxLen+1; i < len; i++){
            var currWord = word.Substring(i, len-i);
            if(string.Compare(currWord, largest) > 0)
                largest = currWord;
        }

        return largest;
    }
}