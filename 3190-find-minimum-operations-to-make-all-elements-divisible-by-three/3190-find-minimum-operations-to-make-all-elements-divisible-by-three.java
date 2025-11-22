class Solution {
    public int minimumOperations(int[] nums) {
        var ops = 0;
        for(var num : nums)
            if(num % 3 != 0) ops++;
        return ops;
    }
}