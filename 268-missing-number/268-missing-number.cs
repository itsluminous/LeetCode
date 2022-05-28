public class Solution {
    public int MissingNumber(int[] nums) {
        var n = nums.Length;
        var total = n * (n+1) / 2;  // AP sum
        foreach(var num in nums)
            total -= num;
        
        return total;   // now only number left in total is the missing number
    }
}