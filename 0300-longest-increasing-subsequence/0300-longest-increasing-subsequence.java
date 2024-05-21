class Solution {
    public int lengthOfLIS(int[] nums) {
        int maxLen = 1, n = nums.length;
        var lis = new int[n];
        lis[0] = nums[0];

        for(var i=1; i<n; i++){
            if(nums[i] > lis[maxLen-1])
                lis[maxLen++] = nums[i];
            else{
                var idx = binarySearch(lis, maxLen-1, nums[i]);
                lis[idx] = nums[i];
            }
        }

        return maxLen;
    }

    // find index of first number >= target
    private int binarySearch(int[] lis, int end, int target){
        int begin = 0, idx = 0;
        while(begin <= end){
            var mid = begin + (end - begin) / 2;
            if(lis[mid] >= target) {
                idx = mid; 
                end = mid-1;
            }
            else 
                begin = mid+1;
        }
        return idx;
    }
}