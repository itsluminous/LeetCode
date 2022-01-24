// Without sorting - O(N)
public class Solution {
    public int CountElements(int[] nums) {
        int n = nums.Length, max = int.MinValue, min = int.MaxValue;
        // find biggest and smallest numbers
        foreach(var num in nums){
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        
        // find all numbers between biggest and smallest number
        var total = 0;
        foreach(var num in nums)
            if(num > min && num < max) total++;
        
        return total;
    }
}

// Accepted - O(logN)
public class Solution1 {
    public int CountElements(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length;
        var total = 0;
        
        // for each number, compare 0th number and last number
        for(var i=1; i<nums.Length-1; i++){
            if(nums[0] < nums[i] && nums[n-1] > nums[i])
                total++;
        }
        return total;
    }
}