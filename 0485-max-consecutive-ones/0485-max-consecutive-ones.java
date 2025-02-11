class Solution {
    public int findMaxConsecutiveOnes(int[] nums) {
        int ans = 0, curr = 0;
        for(var num : nums){
            if(num == 1)
                curr++;
            else if(curr > 0){
                ans = Math.max(ans, curr);
                curr = 0;
            }
        }

        return Math.max(ans, curr);
    }
}