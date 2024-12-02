class Solution {
    public int isPrefixOfWord(String sentence, String searchWord) {
        var words = sentence.split(" ");
        for(var i=0; i<words.length; i++){
            if(words[i].startsWith(searchWord))
                return i+1;
        }
        return -1;
    }
}