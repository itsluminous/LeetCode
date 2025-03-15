class Solution {
    public int minCapability(int[] nums, int k) {
        int low = 1, high = Arrays.stream(nums).max().getAsInt();
        while(low < high){
            var mid = low + (high - low) / 2;
            if(canRob(nums, k, mid))
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }

    // check if we can rob k houses without exceeding a per house limit
    private boolean canRob(int[] nums, int k, int maxRob){
        for(var i=0; i<nums.length && k > 0; i++){
            if(nums[i] <= maxRob){
                k--;
                i++;    // skip next house
            }
        }
        return k == 0;
    }
}