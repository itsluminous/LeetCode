public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var validIdx = 0;
        foreach(var num in nums){
            if(validIdx < 2 || num > nums[validIdx-2])
                nums[validIdx++] = num;
        }
        return validIdx;
    }
}

// Accepted
public class Solution1 {
    public int RemoveDuplicates(int[] nums) {
        if(nums.Length == 1) return 1;
        
        int validIdx = 0, currIdx = 1, n = nums.Length;
        var duplicate = false;
        while(currIdx < n){
            // if prev valid num and current num are different
            if(nums[validIdx] != nums[currIdx]){
                nums[++validIdx] = nums[currIdx];
                duplicate = false;
            }
            // if both numbers are same, and this is 2nd occurence
            else if(!duplicate){
                nums[++validIdx] = nums[currIdx];
                duplicate = true;
            }
            // if both numbers are same, and this is more than 2nd occurence, we ignore it
            
            currIdx++;
        }
        return validIdx+1;
    }
}