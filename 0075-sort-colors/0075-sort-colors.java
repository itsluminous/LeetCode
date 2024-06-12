// using 3 pointers, one pass
// keep all 0 before low ptr, all 2 after high ptr, all 1 from low to high
// mid ptr will be used for traversing from 0 to n-1
class Solution {
    public void sortColors(int[] nums) {
        int low = 0, mid = 0, high = nums.length - 1;

        while(mid <= high){
            if(nums[mid] == 0)
                swap(nums, low++, mid++);
            else if(nums[mid] == 1)
                mid++;
            else 
                swap(nums, high--, mid);
        }
    }

    private void swap(int[] nums, int idx1, int idx2){
        var temp = nums[idx1];
        nums[idx1] = nums[idx2];
        nums[idx2] = temp;
    }
}

// Accepted - using 2 pass
class Solution2pass {
    public void sortColors(int[] nums) {
        var freq = new int[3];
        for(var num : nums) freq[num]++;

        var idx = 0;
        for(var num=0; num<3; num++)
            for(var i=0; i<freq[num]; i++)
                nums[idx++] = num;
    }
}