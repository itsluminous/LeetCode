// Accepted : XOR
// XOR of same num with itself is 0. so XOR of index with the val at that index should be 0.
// at the end, missing number will have its index in XORed value, but not number
public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length, val = 0;
        for(var i=0; i<n; i++)
            val = val ^ i ^ nums[i];
        
        return val ^ n;
    }
}

// Accepted : AP Sum
// From total sum of n number, subtract all numbers present, then remaining value is missing number
public class Solution1 {
    public int MissingNumber(int[] nums) {
        var n = nums.Length;
        var total = n * (n+1) / 2;  // AP sum
        foreach(var num in nums)
            total -= num;
        
        return total;   // now only number left in total is the missing number
    }
}