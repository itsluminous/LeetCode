public class Solution {
    public long ContinuousSubarrays(int[] nums) {
        int left = 0, right = 0, min, max;
        long len = 0, count = 0;

        min = max = nums[0];
        for(right = 0; right < nums.Length; right++){
            max = Math.Max(max, nums[right]);
            min = Math.Min(min, nums[right]);
            if(max - min <= 2) continue;

            // add curr window permutations
            len = right - left;
            count += (len * (len + 1)) / 2;

            // start new window
            left = right;
            max = min = nums[right];

            // move left till diff <= 2
            while(left > 0 && Math.Abs(nums[right] - nums[left-1]) <= 2){
                left--;
                max = Math.Max(max, nums[left]);
                min = Math.Min(min, nums[left]);
            }

            // remove anything that was added as part of prev window
            len = right - left;
            count -= (len * (len + 1)) / 2;
        }

        // add count of final window
        len = right - left;
        count += (len * (len + 1)) / 2;

        return count;
    }
}