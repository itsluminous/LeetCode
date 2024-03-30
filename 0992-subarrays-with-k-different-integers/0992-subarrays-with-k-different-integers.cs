public class Solution {
    public int SubarraysWithKDistinct(int[] nums, int k) {
        return SubarraysWithKOrLessDistinct(nums, k) - SubarraysWithKOrLessDistinct(nums, k-1);
    }

    private int SubarraysWithKOrLessDistinct(int[] nums, int k) {
        var freq = new Dictionary<int, int>();
        int n = nums.Length, count = 0, l = 0;

        for(var r=0; r<n; r++){
            if(freq.ContainsKey(nums[r])) freq[nums[r]]++;
            else freq[nums[r]] = 1;

            while(freq.Count > k){
                freq[nums[l]]--;
                if(freq[nums[l]] == 0) freq.Remove(nums[l]);
                l++;
            }
            count += (r-l+1);
        }

        return count;
    }
}