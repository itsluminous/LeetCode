class Solution {
    public boolean isCircularSentence(String sentence) {
        var words = sentence.split(" ");
        var n = words.length;
        if(words[n-1].charAt(words[n-1].length() - 1) != words[0].charAt(0)) return false;

        for(var i=1; i<n; i++)
            if(words[i].charAt(0) != words[i-1].charAt(words[i-1].length() - 1)) return false;
        return true;
    }
}