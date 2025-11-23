class Solution {
    public int maxSumDivThree(int[] nums) {
        var maxSum = new int[3];    // max sum for remainder 0, 1, 2
        for(var num : nums){
            for(var prevSum : maxSum.clone()){
                var rem = (prevSum + num) % 3;
                maxSum[rem] = Math.max(maxSum[rem], prevSum + num);
            }
        }
        return maxSum[0];   // max sum with no remainder
    }
}