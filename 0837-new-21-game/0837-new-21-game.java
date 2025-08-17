class Solution {
    public double new21Game(int n, int k, int maxPts) {
        if(k == 0 || n >= k + maxPts) return 1; // score will never cross n in this case
        double ans = 0, wsum = 1;   // wsum = sum of sliding window of size maxPts
        var prob = new double[n+1]; // probability of getting score 1 to n+1
        prob[0] = 1;

        for(var i=1; i<=n; i++){
            prob[i] = wsum / maxPts;    // (sum of window of size maxPts) / maxPts
            if(i < k) wsum += prob[i];    // this is not terminal state
            else ans += prob[i];          // terminal state, it cannot be explored further

            if(i >= maxPts) wsum -= prob[i-maxPts]; // subtract if left side will go out of sliding window
        }
        return ans;
    }
}