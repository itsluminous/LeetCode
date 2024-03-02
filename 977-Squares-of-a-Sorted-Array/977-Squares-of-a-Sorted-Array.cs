public class Solution {
    public int[] SortedSquares(int[] nums) {
        var result = new int[nums.Length];
        int left = 0, right = nums.Length -1, pos = nums.Length-1;
        while(left <= right){
            if(Math.Abs(nums[left]) > Math.Abs(nums[right])){
                result[pos--] = nums[left]*nums[left];
                left++;
            }
            else{
                result[pos--] = nums[right]*nums[right];
                right--;
            }   
        }
        return result;
    }
}

// Accepted
public class SolutionSimple {
    public int[] SortedSquares(int[] nums) {
        var n = nums.Length;
        for(var i=0; i<n; i++)
            nums[i] *= nums[i];
        Array.Sort(nums);
        return nums;
    }
}

