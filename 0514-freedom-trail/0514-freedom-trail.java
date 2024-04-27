public class Solution {
    int[][] dp;
    public int findRotateSteps(String ring, String key) {
        dp = new int[ring.length()][key.length()];
        return findRotateSteps(ring, key, 0, 0);
    }

    private int findRotateSteps(String ring, String key, int ringIdx, int keyIdx){
        if(keyIdx == key.length()) return 0;
        if(dp[ringIdx][keyIdx] != 0) return dp[ringIdx][keyIdx];

        var ans = Integer.MAX_VALUE;
        // now check all letters in the ring for a match
        for(var i=0; i<ring.length(); i++){
            if(ring.charAt(i) != key.charAt(keyIdx)) continue;

            // figure out the shorter route is clockwise or anticlockwise
            var stepsBetween = Math.abs(i - ringIdx);
            var stepsAround = ring.length() - stepsBetween;
            var minSteps = Math.min(stepsBetween, stepsAround);

            // find the min steps for remaining chars in key
            minSteps++; // for clicking the middle button
            minSteps += findRotateSteps(ring, key, i, keyIdx+1);
            ans = Math.min(ans, minSteps);
        }

        dp[ringIdx][keyIdx] = ans;
        return ans;
    }
}