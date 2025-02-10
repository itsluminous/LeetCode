class Solution {
    public void rotate(int[] nums, int k) {
        // normalize k
        var n = nums.length;
        k %= n;
        if(k == 0) return;

        // reverse the array
        reverse(nums, 0, n-1);

        // reverse the left & right part separately
        reverse(nums, 0, k-1);
        reverse(nums, k, n-1);
    }

    private void reverse(int[] nums, int start, int end){
        for(int i=start, j=end; i<j; i++, j--){
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}