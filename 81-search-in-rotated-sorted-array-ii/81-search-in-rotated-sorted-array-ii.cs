public class Solution {
    public bool Search(int[] nums, int target) {
        int n=nums.Length, l=0, r=n-1, mid=-1;
        while(l<=r){
            mid = (l+r)/2;
            if(nums[mid] == target) return true;
            
            // If we know for sure right side is sorted or left side is unsorted
            if(nums[mid] < nums[r] || nums[mid] < nums[l]){
                if(target > nums[mid] && target <= nums[r])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            
            // If we know for sure left side is sorted or right side is unsorted
            else if(nums[mid] > nums[l] || nums[mid] > nums[r]){
                if(target < nums[mid] && target >= nums[l])
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            
            //If we get here, that means nums[start] == nums[mid] == nums[end], then shifting out
            //any of the two sides won't change the result but can help remove duplicate from consideration
            else
                r--;
        }
        return false;
    }
}