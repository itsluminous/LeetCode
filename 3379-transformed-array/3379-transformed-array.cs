public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        var n = nums.Length;
        var res = new int[n];

        for(var i=0; i<n; i++)
            res[i] = nums[(((i + nums[i]) % n) + n) % n];
        return res;
    }
}