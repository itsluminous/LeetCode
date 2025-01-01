class Solution {
    public int maxScore(String s) {
        var ones = 0;
        for(var num : s.toCharArray())
            if(num == '1') ones++;
        
        int maxScore = 0, currZero = 0, currOne = 0;
        for(var i=0; i<s.length() - 1; i++){
            if(s.charAt(i) == '0') currZero++;
            else currOne++;

            var currScore = currZero + ones - currOne;
            maxScore = Math.max(maxScore, currScore);
        }
        
        return maxScore;
    }
}