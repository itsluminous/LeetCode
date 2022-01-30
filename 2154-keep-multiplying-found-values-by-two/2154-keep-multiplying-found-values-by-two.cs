// this can be made faster if we hash all numbers and then check if num*2 is present in hash
public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        Array.Sort(nums);
        foreach(var num in nums){
            if(num == original) original*=2;
        }
        return original;
    }
}