public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1) return nums[0];
        int notRobPrev =0, robPrev = nums[0];
        for(var i=1; i<nums.Length; i++){
            var tmp = robPrev;
            robPrev = Math.Max(robPrev, notRobPrev + nums[i]);
            notRobPrev = tmp;
        }
        return Math.Max(robPrev, notRobPrev);
    }
}

// Accepted : This is also doing same thing essentially
public class Solution1 {
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