public class Solution {
    public int Rob(int[] nums) {
        int robPrev=nums[0], notRobPrev=0;
        for(var i=1; i<nums.Length; i++){
            var robCurr = notRobPrev + nums[i];
            notRobPrev = Math.Max(notRobPrev, robPrev);
            robPrev = Math.Max(robPrev, robCurr);
        }
        
        return Math.Max(robPrev, notRobPrev);
    }
}