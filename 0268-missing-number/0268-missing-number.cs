public class Solution {
    public int MissingNumber(int[] nums) {
        var n = nums.Length;
        var apSum = n*(n+1)/2;
        var numSum = nums.Sum();
        return apSum - numSum;
    }
}

// Accepted : XOR
// XOR of same num with itself is 0. so XOR of index with the val at that index should be 0.
// at the end, missing number will have its index in XORed value, but not number
public class SolutionXOR {
    public int MissingNumber(int[] nums) {
        int n = nums.Length, val = 0;
        for(var i=0; i<n; i++)
            val = val ^ i ^ nums[i];
        
        return val ^ n;
    }
}