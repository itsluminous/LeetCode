public class Solution {
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);
        int l = 0, r = nums.Length-1, ops = 0;
        
        while(l < r){
            var sum = nums[l] + nums[r];
            if(sum == k){
                ops++;
                l++;
                r--;
            }
            else if(sum < k) l++;
            else r--;

        }
        return ops;
    }
}