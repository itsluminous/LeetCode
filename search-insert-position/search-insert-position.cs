// Using inbuilt function
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        // suppose you are searching 4 in the list 1,2,3,5. BinarySearch will return -4 
        // to find element >= 4, (-4+1)*-1 which is equal to index 3, i.e. value 5
        var pos = Array.BinarySearch(nums, target);
        if(pos < 0) pos = -1 * (pos+1);
        
        return pos;
    }
}

// Accepted
public class Solution1 {
    public int SearchInsert(int[] nums, int target) {
        var lo = 0;
        var hi = nums.Length -1;
        
        while(lo <= hi){
            var mid = lo + (hi - lo)/2;
            if(nums[mid] == target)
                return mid;
            else if(nums[mid] < target)
                lo = mid+1;
            else
                hi = mid-1;
        }
        
        return lo;
    }
}
