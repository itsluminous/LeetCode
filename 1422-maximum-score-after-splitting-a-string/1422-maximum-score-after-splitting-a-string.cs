public class Solution {
    public int MaxScore(string s) {
        var ones = 0;
        foreach(var num in s)
            if(num == '1') ones++;
        
        int maxScore = 0, currZero = 0, currOne = 0;
        for(var i=0; i<s.Length - 1; i++){
            if(s[i] == '0') currZero++;
            else currOne++;

            var currScore = currZero + ones - currOne;
            maxScore = Math.Max(maxScore, currScore);
        }
        
        return maxScore;
    }
}