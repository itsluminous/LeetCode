public class Solution {
    public boolean increasingTriplet(int[] nums) {
        var n = nums.length;
        int first = Integer.MAX_VALUE, second = Integer.MAX_VALUE;

        for(var num : nums){
            if(num <= first) first = num;           // first element of sequence found
            else if(num <= second) second = num;    // second element of sequence found
            else return true;                       // third element of sequence found
        }

        return false;
    }
}