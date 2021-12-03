// O(n)
public class Solution {
    public int MaximumProduct(int[] nums) {
        int min1 = int.MaxValue, min2 = int.MaxValue;
        int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
        
        foreach(var num in nums){
            // check if bigger negatives are there
            if(num <= min1){
                min2 = min1;
                min1 = num;
            }
            else if(num <= min2)
                min2 = num;
            
            // check if bigger positives are there
            if(num >= max1){
                max3 = max2;
                max2 = max1;
                max1 = num;
            }
            else if(num >= max2){
                max3 = max2;
                max2 = num;
            }
            else if(num >= max3)
                max3 = num;
        }
        
        var leftMax = min1 * min2 * max1;
        var rightMax = max1 * max2 * max3;
        
        return Math.Max(leftMax, rightMax);
    }
}

// n log(n)
public class Solution1 {
    public int MaximumProduct(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length;
        var leftMax = nums[0]*nums[1]*nums[n-1];
        var rightMax = nums[n-3]*nums[n-2]*nums[n-1];
        
        return Math.Max(leftMax, rightMax);
    }
}