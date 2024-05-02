class Solution {
    public int findMaxK(int[] nums) {
        Arrays.sort(nums);
        int left=0, right=nums.length-1;
        while(left < right){
            if(nums[left] > 0) break;                            // answer does not exist
            if(-1*nums[left] == nums[right]) return nums[right]; // found answer
            
            if(-1*nums[left] > nums[right]) left++;
            else right--;
        }
        return -1;
    }
}