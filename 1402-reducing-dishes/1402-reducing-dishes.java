class Solution {
    public int maxSatisfaction(int[] satisfaction) {
        Arrays.sort(satisfaction);

        // maxSum = max sum attained till now, includeSum = sum of all nums included
        int n = satisfaction.length, maxSum = 0, includeSum = 0;
        for(var i=n-1; i>=0; i--){
            var includeCurr = maxSum + includeSum + satisfaction[i];
            if(includeCurr < maxSum) break;
            maxSum = includeCurr;
            includeSum += satisfaction[i];
        }
        return maxSum;
    }
}