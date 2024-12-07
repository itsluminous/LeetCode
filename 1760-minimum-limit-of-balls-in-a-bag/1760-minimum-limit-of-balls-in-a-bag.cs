public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        int low = 1, high = nums.Max();

        while(low < high) {
            var mid = low + (high - low) / 2;
            var possible = Distribute(nums, maxOperations, mid);
            if(!possible) low = mid + 1;
            else high = mid;
        }
        
        return low;
    }
    
    private bool Distribute(int[] nums, int maxOperations, int mid){
        for(var i=0; i<nums.Length; i++){
            // num-1 to avoid count when it is exactly divisble by mid
            // same as Math.ceil(num / mid) - 1
            maxOperations -= (nums[i] - 1) / mid;
            if(maxOperations < 0) return false;
        }
        return true;
    }
}