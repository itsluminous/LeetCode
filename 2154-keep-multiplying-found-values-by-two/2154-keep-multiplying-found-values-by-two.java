// this can be made faster if we hash all numbers and then check if num*2 is present in hash
class Solution {
    public int findFinalValue(int[] nums, int original) {
        Arrays.sort(nums);
        for(var num : nums)
            if(num == original) original*=2;
        return original;
    }
}