public class Solution {
    public int MaximumTop(int[] nums, int k) {
        var n = nums.Length;
        // if no moves allowed, return the topmost element if any
        if (k == 0) return n >= 1 ? nums[0] : -1;
        
        // if only one move is allowed, we can only remove the topmost element
        if (k == 1) return n == 1 ? -1 : nums[1];
        
        // if n=1, we can return the topmost element if k is a even number (keep removing the topmost element and adding it back)
        if (n == 1) return k % 2 == 0 ? nums[0] : -1; 
        
        // we can take `min(k-1, n)` elements and put back the largest one on the top
        var max = GetMaxInRange(nums, 0, Math.Min(n, k-1));
        
        // If `k < n`, we can take all the topmost `k` elements and return the one left at the top
        if (k < n) max = Math.Max(max, nums[k]);
        
        return max;
    }
    
    private int GetMaxInRange(int[] nums, int start, int end){
        var max = -1;
        for(var i=start; i<end; i++){
            max = Math.Max(max, nums[i]);
        }
        
        return max;
    }
}