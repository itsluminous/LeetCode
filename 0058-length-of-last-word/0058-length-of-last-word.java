public class Solution {
    public int lengthOfLastWord(String s) {
        int prevLen=0, len=0;
        var chars = s.toCharArray();
        for(var i=0; i<chars.length; i++){
            if(chars[i] == ' ' && len > 0){
                prevLen = len;
                len = 0;
            }
            else if(chars[i] == ' ') continue;
            else len++;
        }

        return len > 0 ? len : prevLen;
    }

    // Accepted - Using inbuilt split
    public int lengthOfLastWordSplit(String s) {
        var words = s.trim().split(" ");
        return words[words.length-1].length();
    }
}