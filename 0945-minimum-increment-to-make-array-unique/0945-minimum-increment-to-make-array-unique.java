class Solution {
    public int minIncrementForUnique(int[] nums) {
        Arrays.sort(nums);

        int incr = 0, prev = -1;
        for(var num : nums){
            var expected = prev + 1;

            if(num < expected)
                incr += expected - num;
            prev = Math.max(expected, num);
        }

        return incr;
    }
}