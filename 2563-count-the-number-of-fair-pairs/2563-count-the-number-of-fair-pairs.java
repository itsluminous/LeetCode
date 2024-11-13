// @votrubac : since nums[i] + nums[j] == nums[j] + nums[i], the i < j condition degrades to i != j
// count all pairs whose sum <= upper bound (this will include pairs lower than lower bound)
// count all pairs whose sum < lower bound
// subtract lower bound pairs from upper bound pairs, to get pairs b/w lower & upper
class Solution {
    public long countFairPairs(int[] nums, int lower, int upper) {
        Arrays.sort(nums);
        return countLessPairs(nums, upper) - countLessPairs(nums, lower-1);
    }

    private long countLessPairs(int[] nums, int maxVal){
        long count = 0;
        for(int l=0, r=nums.length-1; l < r; l++){
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
class SolutionBS {
    public long countFairPairs(int[] nums, int lower, int upper) {
        Arrays.sort(nums);
        var n = nums.length;
        long count = 0;
        for(var i=0; i<n; i++){
            // index of first element with sum < lower bound
            var low = getLowerBound(nums, i+1, n-1, lower - nums[i]);
            // index of first element with sum <= upper bound
            var high = getLowerBound(nums, i+1, n-1, upper - nums[i] + 1);

            count += high - low;
        }
        return count;
    }

    private long getLowerBound(int[] nums, int low, int high, int num){
        while(low <= high){
            var mid = low + (high - low) / 2;
            if(nums[mid] >= num) high = mid-1;
            else low = mid+1;
        }
        return low;
    }
}