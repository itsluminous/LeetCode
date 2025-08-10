class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
        int n = fruits.length, ans = 0;
        int left = 0, sum = 0;

        // slide right window
        for(var right = 0; right < n; right++){
            sum += fruits[right][1];
            // slide left window if it is outside k range
            while(left <= right && !valid(fruits, startPos, k, left, right)){
                sum -= fruits[left][1];
                left++;
            }
            ans = Math.max(ans, sum);
        }
        return ans;
    }

    private boolean valid(int[][] fruits, int startPos, int k, int left, int right){
        // optimal path will be either left only, or right only, or just one u-turn
        var stepsForFruitsInMid = fruits[right][0] - fruits[left][0];
        var stepsForLeftThenRight = Math.abs(startPos - fruits[left][0]);
        var stepsForRightThenLeft = Math.abs(startPos - fruits[right][0]);
        var stepsForUturn = Math.min(stepsForLeftThenRight, stepsForRightThenLeft);
        return stepsForUturn + stepsForFruitsInMid <= k;
    }
}