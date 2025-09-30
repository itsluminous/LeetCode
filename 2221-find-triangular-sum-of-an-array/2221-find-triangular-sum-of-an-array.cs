public class Solution {
    public int TriangularSum(int[] nums) {
        var n = nums.Length;
        while(n > 1){
            for(var i=0; i<n-1; i++)
                nums[i] = (nums[i] + nums[i+1]) % 10;
            n--;
        }
        return nums[0];
    }
}