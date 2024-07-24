public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        var n = nums.Length;
        
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
        var indices = Enumerable.Range(0, n).ToArray();
        Array.Sort(indices, (i1, i2) => mapped[i1] - mapped[i2]);

        // return the sorted nums
        var sorted = indices.Select(i => nums[i]).ToArray();
        return sorted;
    }
}