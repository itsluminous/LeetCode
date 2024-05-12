class Solution {
    public int removeDuplicates(int[] nums) {
        int n = nums.length, left = 0, right = 0;
        var seen = new boolean[201];

        while(right < n){
            if(!seen[nums[right] + 100]){
                nums[left++] = nums[right];
                seen[nums[right] + 100] = true;
            }
            right++;
        }

        return left;
    }
}