class Solution {
    public String reversePrefix(String word, char ch) {
        var idx = word.indexOf(ch);
        if(idx == -1) return word;

        var ans = new StringBuilder();
        for(var i=idx; i>=0; i--) ans.append(word.charAt(i));
        for(var i=idx+1; i<word.length(); i++) ans.append(word.charAt(i));
        return ans.toString();
    }
}