public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int n = nums.Length, l = 0, r = 0, max = 1;
        var freq = new Dictionary<int, int>();

        while(r < n){
            if(freq.ContainsKey(nums[r])) freq[nums[r]]++;
            else freq[nums[r]] = 1;

            while(freq[nums[r]] > k){
                freq[nums[l]]--;
                l++;
            }
            max = Math.Max(max, r-l+1);
            r++;
        }

        return max;
    }
}