public class Solution {
    public int MaxSumDivThree(int[] nums) {
        var maxSum = new int[3];    // max sum for remainder 0, 1, 2
        foreach(var num in nums){
            foreach(var prevSum in maxSum.ToArray()){
                var rem = (prevSum + num) % 3;
                maxSum[rem] = Math.Max(maxSum[rem], prevSum + num);
            }
        }
        return maxSum[0];   // max sum with no remainder
    }
}