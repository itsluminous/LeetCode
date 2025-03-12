public class Solution {
    public int MaximumCount(int[] nums) {
        var n = nums.Length;
        int leftZero = n, rightZero = n;

        // find left most zero
        int left = 0, right = n-1;
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(nums[mid] < 0)
                left = mid + 1;
            else {
                leftZero = mid;
                right = mid - 1;
            }
        }
        
        // find right most zero
        left = 0; right = n-1;
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(nums[mid] <= 0)
                left = mid + 1;
            else {
                rightZero = mid;
                right = mid - 1;
            }
        }
        
        return Math.Max(n - rightZero, leftZero);
    }
}

// accepted - O(n)
public class SolutionLinear {
    public int MaximumCount(int[] nums) {
        int n = nums.Length, idx = 0;

        // count negatives
        while(idx < n && nums[idx] < 0) idx++;
        var neg = idx;

        // skip zeroes, then count positives
        while(idx < n && nums[idx] == 0) idx++;
        var pos = n - idx;

        return Math.Max(pos, neg);
    }
}