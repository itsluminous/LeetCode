// INTUTION : the edges array is irrelevant
// if every node is connected in the tree (transitively), then we can pick any two nodes and xor them
// because (a ^ k) ^ k = a
// so if I have edge [0,1] & [0,2] => here [1,2] are not even connected directly
// but still if I do => [0^k, 1^k] and then [0^k, 2^k] then finally number will be [0, 1^k], [0, 2^k]
// so we were able to xor [1,2] even though there is no direct connection

// with above knowledge, we simply perform backtracking with memoization
public class Solution {
    long[,] dp;

    public long MaximumValueSum(int[] nums, int k, int[][] edges) {
        var n = nums.Length;
        dp = new long[n,2];     // [node, XORed even till now or not]
        for(var i=0; i<n; i++)
            dp[i,0] = dp[i,1] = -1;

        return MaximumValueSum(nums, k, 0, 1);  // isEven = 1 because we have XORed 0 nodes, which is even
    }

    public long MaximumValueSum(int[] nums, int k, int currIdx, int isEven) {
        var n = nums.Length;

        // base case
        // if any node is xored odd times, then it changes value
        // even times means it will have its original value
        if(currIdx == n)
            return isEven == 1 ? 0 : long.MinValue;
        
        if(dp[currIdx, isEven] != -1) return dp[currIdx, isEven];

        // find out whether xoring curr num is better or not
        var notXor = nums[currIdx] + MaximumValueSum(nums, k, currIdx+1, isEven);
        var xor = (nums[currIdx] ^ k) + MaximumValueSum(nums, k, currIdx+1, 1 - isEven);

        dp[currIdx, isEven] = Math.Max(xor, notXor);
        return dp[currIdx, isEven];
    }
}