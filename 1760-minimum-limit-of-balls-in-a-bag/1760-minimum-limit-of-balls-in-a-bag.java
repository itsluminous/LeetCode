class Solution {
    public int minimumSize(int[] nums, int maxOperations) {
        int low = 1, high = Arrays.stream(nums).max().getAsInt();

        while(low < high) {
            var mid = low + (high - low) / 2;
            var possible = distribute(nums, maxOperations, mid);
            if(!possible) low = mid + 1;
            else high = mid;
        }
        
        return low;
    }
    
    private boolean distribute(int[] nums, int maxOperations, int mid){
        for(var i=0; i<nums.length; i++){
            // num-1 to avoid count when it is exactly divisble by mid
            // same as Math.ceil(num / mid) - 1
            maxOperations -= (nums[i] - 1) / mid;
            if(maxOperations < 0) return false;
        }
        return true;
    }
}