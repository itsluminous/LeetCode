public class Solution {
    public int MinCapability(int[] nums, int k) {
        // function to count how many houses can be robbed without exceeding a per house limit
        int RobCount(int limit){
            var count = 0;
            for(var i=0; i<nums.Length; i++){
                if(nums[i] <= limit){
                    count++;
                    i++;    // skip next house
                }
            }
            return count;
        }

        int left = 1, right = nums.Max();
        while(left < right){
            var mid = left + (right - left) / 2;
            var count = RobCount(mid);
            if(count >= k) right = mid;
            else left = mid+1;
        }

        return left;
    }
}