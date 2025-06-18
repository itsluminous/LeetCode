class Solution {
    public int[][] divideArray(int[] nums, int k) {
        Arrays.sort(nums);
        
        var n = nums.length;
        var ansLen = n/3;
        var ans = new int[ansLen][3];

        for(var i=0; i<ansLen; i++){
            var idx = i * 3;
            if(nums[idx+2] - nums[idx] > k) return new int[0][0];
            ans[i] = new int[]{nums[idx], nums[idx+1], nums[idx+2]};
        }

        return ans;
    }
}