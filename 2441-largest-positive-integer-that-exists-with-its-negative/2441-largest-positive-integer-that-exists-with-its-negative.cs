public class Solution {
    public int FindMaxK(int[] nums) {
        Array.Sort(nums);
        int left=0, right=nums.Length-1;
        while(left < right){
            if(nums[left] > 0) break;                            // answer does not exist
            if(-1*nums[left] == nums[right]) return nums[right]; // found answer
            
            if(-1*nums[left] > nums[right]) left++;
            else right--;
        }
        return -1;
    }
}