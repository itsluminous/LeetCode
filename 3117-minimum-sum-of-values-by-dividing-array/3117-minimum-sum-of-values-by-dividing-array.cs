public class Solution {
    // 3d dp for "nums index", "andValues index", "calculated AND value"
    private Dictionary<(int, int, int), int> dp = new Dictionary<(int, int, int), int>();
    int allBitsSet = (1 << 30) - 1;
    int n, m;
    int maxVal = (int)1e9;

    public int MinimumValueSum(int[] nums, int[] andValues) {
        (n, m) = (nums.Length, andValues.Length);
        
        // Initialize the calculation with all bits set to 1 in the mask
        int ans = CalculateMinSum(nums, andValues, allBitsSet, 0, 0);
        
        // Return the result if it's finite, otherwise return -1
        return ans < maxVal ? ans : -1;
    }

    // Define a recursive function to calculate the minimum sum
    private int CalculateMinSum(int[] nums, int[] andValues, int mask, int n1, int m1) {
        // if both arrays are exhausted
        if (m1 == m && n1 == n) return 0;
        // if either array is exhausted
        if (m1 == m || n1 == n) return maxVal;
        
        // Check if the result is already calculated and cached
        if (dp.ContainsKey((mask, n1, m1))) return dp[(mask, n1, m1)];
        
        // Update the mask with bitwise AND operation
        mask &= nums[n1];

        // If the updated mask is less than the corresponding and_value, its not possible to get the expected value
        // because the AND value can only decrease if we add more numbers to it
        if (mask < andValues[m1]) return maxVal;
        
        // If the updated mask equals the corresponding and_value
        // then try to split the array at this point
        var split = maxVal;
        if (mask == andValues[m1]) 
            // Add nums[n1] to the sum and increment both n1 and m1
            split = nums[n1] + CalculateMinSum(nums, andValues, allBitsSet, n1 + 1, m1 + 1);

        // find out case when we don't split 
        // Increment n1 to move to the next element in nums
        var notSplit = CalculateMinSum(nums, andValues, mask, n1 + 1, m1);

        // Return the minimum of two cases
        var result = Math.Min(notSplit, split);
        dp[(mask, n1, m1)] = result;
        return result;
    }
}