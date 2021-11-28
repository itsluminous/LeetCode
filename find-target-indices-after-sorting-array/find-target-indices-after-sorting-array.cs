public class Solution {
    public IList<int> TargetIndices(int[] nums, int target) {
        var n = nums.Length;
        Array.Sort(nums);
        int low = 0, high = n - 1, startIndex = -1;
        // get the start index of target number
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (nums[mid] > target) {
                high = mid - 1;
            } else if (nums[mid] == target) {
                startIndex = mid;
                high = mid - 1;
            } else
                low = mid + 1;
        }
        
        if(startIndex == -1) return new List<int>();
        
        // get the end index of target number
        var endIndex = -1;
        low = 0; high = n - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (nums[mid] > target) {
                high = mid - 1;
            } else if (nums[mid] == target) {
                endIndex = mid;
                low = mid + 1;
            } else
                low = mid + 1;
        }
        
        var result = new List<int>();
        for(var i=startIndex; i<=endIndex;i++){
            result.Add(i);
        }
        
        return result;
    }
}