class Solution {
    public int findPeakElement(int[] nums) {
        int n = nums.length, left = 0, right = n-1;
        while(left < right){
            var mid = left + (right-left)/2;
            // if it is on left slope
            if(mid != n && nums[mid] < nums[mid+1]) left = mid+1;
            // it is on right slope
            else right = mid;
        }
        return left;
    }
}