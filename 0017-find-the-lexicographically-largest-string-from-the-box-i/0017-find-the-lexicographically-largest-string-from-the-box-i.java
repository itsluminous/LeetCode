class Solution {
    public String answerString(String word, int numFriends) {
        if(numFriends == 1) return word;
        
        var len = word.length();
        var maxLen = len-numFriends+1;  // max length of ans
        
        // check all strings of size maxLen
        var largest = word.substring(0, maxLen);
        for(var i=1; i+maxLen<=len; i++){
            var currWord = word.substring(i, i+maxLen);
            if(currWord.compareTo(largest) > 0)
                largest = currWord;
        }

        // try all remaining chars at end (of size < maxLen)
        for(var i=len-maxLen+1; i < len; i++){
            var currWord = word.substring(i, len);
            if(currWord.compareTo(largest) > 0)
                largest = currWord;
        }

        return largest;
    }
}