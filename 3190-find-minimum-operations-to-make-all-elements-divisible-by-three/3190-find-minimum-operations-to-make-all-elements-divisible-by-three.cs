public class Solution {
    public int MinimumOperations(int[] nums) {
        var ops = 0;
        foreach(var num in nums)
            if(num % 3 != 0) ops++;
        return ops;
    }
}