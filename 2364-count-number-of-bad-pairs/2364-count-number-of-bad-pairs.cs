public class Solution {
    public long CountBadPairs(int[] nums) {
        // count how many numbers differ from their index
        var numsCount = nums.Length;
        var mismatch = new Dictionary<int, int>();  // key = diff, val = count
        for(var i=0; i<numsCount; i++){
            var diff = nums[i] - i;
            if(mismatch.ContainsKey(diff)) mismatch[diff]++;
            else mismatch[diff] = 1;
        }

        // a set of numbers with same diff will always make good pairs
        // so we can only pair them with any other no. in the world
        long count = 0;
        foreach(var freq in mismatch.Values){
            numsCount -= freq;
            count += freq * numsCount;
        }

        return count;
    }
}