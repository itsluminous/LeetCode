class Solution {
    public int scoreOfString(String s) {
        var score = 0;
        for(var i=0; i<s.length()-1; i++)
            score += Math.abs(s.charAt(i) - s.charAt(i+1));
        return score;
    }
}