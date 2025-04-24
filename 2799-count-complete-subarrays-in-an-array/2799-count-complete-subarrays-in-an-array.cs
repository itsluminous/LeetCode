public class Solution {
    public int CountCompleteSubarrays(int[] nums) {
        int n = nums.Length, ans = 0;

        // count unique elements in whole array
        var uniqSet = new HashSet<int>();
        foreach(var num in nums) uniqSet.Add(num);
        var uniqCount = uniqSet.Count;

        // sliding window to find complete subarrays
        var freq = new Dictionary<int, int>();
        var l = 0;
        for(var r=0; r<n; r++){
            if(!freq.ContainsKey(nums[r])) freq[nums[r]] = 1;
            else freq[nums[r]]++;
            while(freq.Count == uniqCount){
                ans += n - r;   // adding any element on right will not change curr uniq count

                // move left pointer
                if(freq[nums[l]] == 1) freq.Remove(nums[l]);
                else freq[nums[l]]--;
                l++;
            }
        }

        return ans;
    }
}