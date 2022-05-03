public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int n = nums.Length, start = -1, end = -1;
        
        // clone the array and then sort it
        var sorted = (int[]) nums.Clone();
        Array.Sort(sorted);
        
        // compare sorted array with original to find start and end index of different numbers
        for(var i=0; i<n; i++){
            if(nums[i] != sorted[i]){
                start = i;
                break;
            }
        }
        
        for(var i=n-1; i>0; i--){
            if(nums[i] != sorted[i]){
                end = i+1;
                break;
            }
        }
        
        // return length of subarray to be sorted
        return end-start;
    }
}