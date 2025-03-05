class Solution {
    public int minCapability(int[] nums, int k) {
        int left = 1, right = Arrays.stream(nums).max().getAsInt();
        while(left < right){
            var mid = left + (right - left) / 2;
            var count = robCount(nums, mid);
            if(count >= k) right = mid;
            else left = mid+1;
        }

        return left;
    }


    // function to count how many houses can be robbed without exceeding a per house limit
    private int robCount(int[] nums, int limit){
        var count = 0;
        for(var i=0; i<nums.length; i++){
            if(nums[i] <= limit){
                count++;
                i++;    // skip next house
            }
        }
        return count;
    }
}