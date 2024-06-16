// if we have a number `num` present, then we definitely have all numbers till `num` possible
// so we just need to keep track of what is max number we can reach
public class Solution {
    public int MinPatches(int[] nums, int n) {
        long maxNum = 1;
        int nl = nums.Length, idx = 0, patched = 0;
        while(maxNum <= n){
            if(idx  < nl && nums[idx] <= maxNum){
                maxNum += nums[idx];
                idx++;
            }
            else{
                patched++;
                maxNum *= 2;
            }
        }

        return patched;
    }
}