class Solution {
    public long mostPoints(int[][] questions) {
        var n = questions.length;
        
        // calculate max points achievable when starting from index i
        long maxPossible = 0;
        var maxPoints = new long[n];
        for(var i=n-1; i>=0; i--){
            int points = questions[i][0], brainpower = questions[i][1];
            
            // score if we include curr point
            maxPoints[i] = points;
            var nextIdx = i + brainpower + 1;
            if(nextIdx < n)
                maxPoints[i] += maxPoints[nextIdx];
            
            // if the score after including curr point is bad, skip it
            if(maxPoints[i] < maxPossible) maxPoints[i] = maxPossible;
            else maxPossible = maxPoints[i];
        }

        return maxPossible;
    }
}