class Solution {
    public String[] findRelativeRanks(int[] score) {
        var toppers = new String[]{"Gold Medal", "Silver Medal", "Bronze Medal"};
        int n = score.length, position = 1, maxScore = Arrays.stream(score).max().getAsInt();

        // make an array of same size as max score, then place all players in that array based on score
        var scoreToIdx = new int[maxScore+1];
        for(var i=0; i<n; i++) scoreToIdx[score[i]] = i+1;

        // now traverse array from right to left and fill the rank array
        var rank = new String[n];
        for(var i=maxScore; i>=0; i--){
            if(scoreToIdx[i] == 0) continue;

            var idx = scoreToIdx[i]-1;
            if(position <= 3) rank[idx] = toppers[position-1];
            else rank[idx] = String.valueOf(position);
            position++;
        }

        return rank;
    }
}