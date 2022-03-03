public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        var sum = 0;    // total sequences
        var curr = 0;   // the current sequence
        for(int i=2; i<nums.Length; i++){
            if(nums[i]-nums[i-1] == nums[i-1]-nums[i-2]){
                curr++;
                sum += curr;    // not sum++ because with every letter added in curr, we create those many new sequence
            }
            else
                curr = 0;
        }
        return sum;
    }
}