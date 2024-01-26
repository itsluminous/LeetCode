public class Solution {
    public int MinOperations(int[] nums) {
        var freq = new Dictionary<int,int>();
        foreach(var num in nums){
            if(freq.ContainsKey(num)) freq[num] += 1;
            else freq[num] = 1;
        }

        var ops = 0;
        foreach(var val in freq.Values){
            // can never be divided by 2 or 3
            if(val == 1)
                return -1;
            else{
                ops += val / 3;
                // it will have to be divided by 2
                if(val % 3 != 0) ops++;
            }
        }

        return ops;
    }
}