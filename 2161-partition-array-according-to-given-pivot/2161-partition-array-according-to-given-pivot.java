class Solution {
    public int[] pivotArray(int[] nums, int pivot) {
        var n = nums.length;
        var ans = new int[n];
        int smallIdx = 0, bigIdx = n-1;

        // iterate from both directions (left & right), and fill ans 
        for(int i=0, j=n-1; i<n; i++, j--){
            if(nums[i] < pivot)
                ans[smallIdx++] = nums[i];
            if(nums[j] > pivot)
                ans[bigIdx--] = nums[j];
        }

        // fill remaining positions with nums equal to pivot
        while(smallIdx <= bigIdx)
            ans[smallIdx++] = pivot;
        
        return ans;
    }
}

// Accepted - modifying original nums array
class SolutionArr {
    public int[] pivotArray(int[] nums, int pivot) {
        var n = nums.length;
        var bigger = new int[n];    // array to store numbers bigger than pivot
        var eq = 0;                 // count of numbers equal to pivot
        int smallIdx = 0, bigIdx = 0;

        // move all small to left side in nums
        // copy all big ones to "bigger" array
        // and just keep a count of numbers equal to pivot
        for(var i=0; i<n; i++){
            if(nums[i] < pivot)
                nums[smallIdx++] = nums[i];
            else if(nums[i] > pivot)
                bigger[bigIdx++] = nums[i];
            else
                eq++;
        }

        // fill up all equal numbers
        while(eq-- > 0)
            nums[smallIdx++] = pivot;
        
        // fill up all bigger numbers
        for(var i=0; i<bigIdx; i++)
            nums[smallIdx++] = bigger[i];
        
        return nums;
    }
}