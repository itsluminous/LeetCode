// @votrubac : since nums[i] + nums[j] == nums[j] + nums[i], the i < j condition degrades to i != j
// count all pairs whose sum <= upper bound (this will include pairs lower than lower bound)
// count all pairs whose sum < lower bound
// subtract lower bound pairs from upper bound pairs, to get pairs b/w lower & upper
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        return CountLessPairs(nums, upper) - CountLessPairs(nums, lower-1);
    }

    private long CountLessPairs(int[] nums, int maxVal){
        long count = 0;
        for(int l=0, r=nums.Length-1; l < r; l++){
            while(l < r && nums[l] + nums[r] > maxVal) r--;
            count += r - l;
        }
        return count;
    }
}

// @votrubac : since nums[i] + nums[j] == nums[j] + nums[i], the i < j condition degrades to i != j
// for each index in array:
//   get index of first element with sum < lower bound
//   get index of first element with sum <= upper bound
//   count = upper bound idx - lower bound idx
public class SolutionBS {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        var n = nums.Length;
        long count = 0;
        for(var i=0; i<n; i++){
            // index of first element with sum < lower bound
            var low = GetLowerBound(nums, i+1, n-1, lower - nums[i]);
            // index of first element with sum <= upper bound
            var high = GetLowerBound(nums, i+1, n-1, upper - nums[i] + 1);

            count += high - low;
        }
        return count;
    }

    private long GetLowerBound(int[] nums, int low, int high, int num){
        while(low <= high){
            var mid = low + (high - low) / 2;
            if(nums[mid] >= num) high = mid-1;
            else low = mid+1;
        }
        return low;
    }
}