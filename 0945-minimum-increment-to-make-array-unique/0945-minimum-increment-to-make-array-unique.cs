public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);

        int incr = 0, prev = -1;
        foreach(var num in nums){
            var expected = prev + 1;

            if(num < expected)
                incr += expected - num;
            prev = Math.Max(expected, num);
        }

        return incr;
    }
}