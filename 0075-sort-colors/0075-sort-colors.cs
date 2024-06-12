// using 3 pointers, one pass
// keep all 0 before low ptr, all 2 after high ptr, all 1 from low to high
// mid ptr will be used for traversing from 0 to n-1
public class Solution {
    public void SortColors(int[] nums) {
        int low = 0, mid = 0, high = nums.Length - 1;

        while(mid <= high){
            if(nums[mid] == 0){
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++;
                mid++;
            }
            else if(nums[mid] == 1)
                mid++;
            else {
                (nums[high], nums[mid]) = (nums[mid], nums[high]);
                high--;
            }
        }
    }
}

// Accepted - using 2 pass
public class Solution2Pass {
    public void SortColors(int[] nums) {
        var freq = new int[3];
        foreach(var num in nums) freq[num]++;

        var idx = 0;
        for(var num=0; num<3; num++)
            for(var i=0; i<freq[num]; i++)
                nums[idx++] = num;
    }
}