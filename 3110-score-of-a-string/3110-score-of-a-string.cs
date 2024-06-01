public class Solution {
    public int ScoreOfString(string s) {
        var score = 0;
        for(var i=0; i<s.Length-1; i++)
            score += Math.Abs(s[i] - s[i+1]);
        return score;
    }
}