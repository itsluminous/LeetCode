public class Solution {
    int[,] dp;
    public int FindRotateSteps(string ring, string key) {
        dp = new int[ring.Length,key.Length];
        return FindRotateSteps(ring, key, 0, 0);
    }

    private int FindRotateSteps(string ring, string key, int ringIdx, int keyIdx){
        if(keyIdx == key.Length) return 0;
        if(dp[ringIdx,keyIdx] != 0) return dp[ringIdx,keyIdx];

        var ans = int.MaxValue;
        // now check all letters in the ring for a match
        for(var i=0; i<ring.Length; i++){
            if(ring[i] != key[keyIdx]) continue;

            // figure out the shorter route is clockwise or anticlockwise
            var stepsBetween = Math.Abs(i - ringIdx);
            var stepsAround = ring.Length - stepsBetween;
            var minSteps = Math.Min(stepsBetween, stepsAround);

            // find the min steps for remaining chars in key
            minSteps++; // for clicking the middle button
            minSteps += FindRotateSteps(ring, key, i, keyIdx+1);
            ans = Math.Min(ans, minSteps);
        }

        dp[ringIdx,keyIdx] = ans;
        return ans;
    }
}