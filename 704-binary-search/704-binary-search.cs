public class Solution {
    public int Search(int[] nums, int target) {
        var n = nums.Length;
        int low = 0, high = n - 1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (nums[mid] > target)
                high = mid - 1;
            else if (nums[mid] < target)
                low = mid + 1;
            else
                return mid;
        }
        return -1;
    }
}