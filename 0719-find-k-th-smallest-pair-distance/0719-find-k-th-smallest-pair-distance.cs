public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        var n = nums.Length;
        Array.Sort(nums);

        // max distance b/w two nums is dist between largest & smallest
        int low = 0, high = nums[n-1] - nums[0];
        
        // binary search to find the distance at kth index
        while(low < high){
            var mid = low + (high - low) / 2;
            var count = CountPairsWithMaxDistance(nums, mid);

            if(count < k) low = mid+1;
            else high = mid;
        }

        return low;
    }

    private int CountPairsWithMaxDistance(int[] nums, int k){
        int n = nums.Length, count = 0;

        for(int left=0, right=0; right < n; right++){
            // increment left till distance > k
            while(nums[right] - nums[left] > k) left++;
            count += (right - left);
        }

        return count;
    }
}