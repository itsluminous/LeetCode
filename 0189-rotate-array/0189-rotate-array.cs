public class Solution {
    public void Rotate(int[] nums, int k) {
        // normalize k
        var n = nums.Length;
        k %= n;
        if(k == 0) return;

        // reverse the array
        Array.Reverse(nums);

        // reverse the left & right part separately
        for(int i=0, j=k-1; i<j; i++, j--)
            (nums[i], nums[j]) = (nums[j], nums[i]);
        
        for(int i=k, j=n-1; i<j; i++, j--)
            (nums[i], nums[j]) = (nums[j], nums[i]);
    }
}