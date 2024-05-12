public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int n = nums.Length, left = 0, right = 0;
        var seen = new bool[201];

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