public class Solution {
    public int Search(int[] nums, int target) {
        int n=nums.Length, l=0, r=n-1, mid=-1;
        while(l<r){
            mid = (l+r)/2;
            if(nums[mid] > nums[r]) l=mid+1;
            else r=mid;
        }
        // rotated l times
        return SearchRotated(nums, target, l);
    }
    
    private int SearchRotated(int[] nums, int target, int rotation){
        int n=nums.Length, l=0, r=n-1;
        while(l<=r){    // less than equal to so that we can handle single length array
            var mid = (l+r)/2;
            var realMid = (mid+rotation)%n;
            if(nums[realMid] == target) return realMid;
            if(nums[realMid] < target) l=mid+1;
            else r=mid-1;   // r=mid-1 and not r=mid because while loop condition is l<=r, hence avoiding infinite loop
        }
        return -1;
    }
}