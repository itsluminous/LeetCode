class Solution {
    public int[] sortJumbled(int[] mapping, int[] nums) {
        var n = nums.length;
        
        // create a mapped array
        var mapped = new int[n];
        for(var i=0; i<n; i++){
            var num = nums[i];
            int numMap = 0, mul = 1;
            while(num > 9){
                numMap += mul * mapping[num % 10];
                num /= 10;
                mul *= 10;
            }
            numMap += mul * mapping[num % 10];
            mapped[i] = numMap;
        }

        // sort the indexes as per mapped value
        var indices = new Integer[n];
        for(var i=0; i<n; i++) indices[i] = i;
        Arrays.sort(indices, (i1, i2) -> Integer.compare(mapped[i1], mapped[i2]));

        // return the sorted nums
        var sorted = new int[n];
        for(var i=0; i<n; i++)
            sorted[i] = nums[indices[i]];
        return sorted;
    }
}