public class Solution {
    public int[] SortArray(int[] nums) {
        return MergeSort(nums, 0, nums.Length - 1);
    }

    private int[] MergeSort(int[] nums, int left, int right){
        if(left >= right) return nums;
        var mid = left + (right - left)/2;
        MergeSort(nums, left, mid);
        MergeSort(nums, mid+1, right);
        Merge(nums, left, right);
        return nums;
    }

    private void Merge(int[] nums, int left, int right){
        var mid = left + (right - left)/2;
        var temp = new int[right - left + 1];
        int leftIdx = left, rightIdx = mid+1, tempIdx = 0;

        // copy data into temp array in ascending order
        while (leftIdx <= mid || rightIdx <= right)
            if (leftIdx > mid || rightIdx <= right && nums[leftIdx] > nums[rightIdx]) 
                temp[tempIdx++] = nums[rightIdx++];
            else 
                temp[tempIdx++] = nums[leftIdx++];

        // copy data from temp to actual nums
        for (int i = left, t = 0; i <= right; i++, t++)
            nums[i] = temp[t];
    }
}