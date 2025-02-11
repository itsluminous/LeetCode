public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int ans = 0, curr = 0;
        foreach(var num in nums){
            if(num == 1)
                curr++;
            else if(curr > 0){
                ans = Math.Max(ans, curr);
                curr = 0;
            }
        }

        return Math.Max(ans, curr);
    }
}