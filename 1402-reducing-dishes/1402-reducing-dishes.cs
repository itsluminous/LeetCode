public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        Array.Sort(satisfaction, (s1, s2) => s2-s1);    // sort desc

        // maxSum = max sum attained till now, includeSum = sum of all nums included
        int n = satisfaction.Length, maxSum = 0, includeSum = 0;
        for(var i=0; i<n; i++){
            var includeCurr = maxSum + includeSum + satisfaction[i];
            if(includeCurr < maxSum) break;
            maxSum = includeCurr;
            includeSum += satisfaction[i];
        }
        return maxSum;
    }
}