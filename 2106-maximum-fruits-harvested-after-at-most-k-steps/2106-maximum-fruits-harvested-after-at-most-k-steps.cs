public class Solution {
    public int MaxTotalFruits(int[][] fruits, int startPos, int k) {
        int n = fruits.Length, ans = 0;
        int left = 0, sum = 0;

        // slide right window
        for(var right = 0; right < n; right++){
            sum += fruits[right][1];
            // slide left window if it is outside k range
            while(left <= right && !Valid(fruits, startPos, k, left, right)){
                sum -= fruits[left][1];
                left++;
            }
            ans = Math.Max(ans, sum);
        }
        return ans;
    }

    private bool Valid(int[][] fruits, int startPos, int k, int left, int right){
        // optimal path will be either left only, or right only, or just one u-turn
        var stepsForFruitsInMid = fruits[right][0] - fruits[left][0];
        var stepsForLeftThenRight = Math.Abs(startPos - fruits[left][0]);
        var stepsForRightThenLeft = Math.Abs(startPos - fruits[right][0]);
        var stepsForUturn = Math.Min(stepsForLeftThenRight, stepsForRightThenLeft);
        return stepsForUturn + stepsForFruitsInMid <= k;
    }
}