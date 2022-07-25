public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int left = 0, right = nums.Length - 1, mid;
        int leftIdx = -1, rightIdx = -1;
        
        while(left <= right) {
            mid = left + ( right - left) / 2;
            if(nums[mid] > target)
                right = mid - 1;
            else if(nums[mid] < target)
                left = mid + 1;
            else{
                leftIdx = mid;
                right = mid - 1;
            }
        }
        
        if(leftIdx == -1) return new []{-1, -1};
        
        left = leftIdx; right = nums.Length - 1;
            
        while(left <= right) {
            mid = left + ( right - left) / 2;
            if(nums[mid] > target)
                right = mid - 1;
            else if(nums[mid] < target)
                left = mid + 1;
            else{
                rightIdx = mid;
                left = mid + 1;
            }
        }
        
        return new []{leftIdx, rightIdx};
    }
}

// Accepted - Prev sln
public class Solution1 {
    public int[] SearchRange(int[] nums, int target) {
        int n=nums.Length, l=0, r=n-1, mid=-1;
        // first find the left most index
        while(l<r){
            mid = (l+r)/2;
            if(nums[mid] < target) l = mid + 1;
            else r = mid;
        }
        
        // if target is not found
        if(n < 1 || l >= n || nums[l] != target) return new []{-1,-1};   
        
        var result = new []{l,l};
        // if only one item in nums, then l and r are same
        if(n == 1) return result;
        
        // now find the right most index
        l=mid;
        r=n-1;
        while(l<r){
            mid = (l+r)/2 + 1;   // Make mid biased to the right so that we don't get in infinite loop
            if(nums[mid] > target) r = mid-1;
            else l = mid;
        }
        
        // assign the rightmost index and return
        result[1] = r;
        return result;
    }
}