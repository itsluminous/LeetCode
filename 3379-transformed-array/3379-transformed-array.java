class Solution {
    public int[] constructTransformedArray(int[] nums) {
        var n = nums.length;
        var res = new int[n];

        for(var i=0; i<n; i++)
            res[i] = nums[(((i + nums[i]) % n) + n) % n];
        return res;
    }
}