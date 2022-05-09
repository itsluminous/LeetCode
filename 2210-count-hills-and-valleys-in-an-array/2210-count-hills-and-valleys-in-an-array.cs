public class Solution {
    public int CountHillValley(int[] nums) {
        var n = nums.Length;  
        var dir = 0;    // direction = 1 means up, -1 means down
        var count = 0;
        
        if(nums[1] > nums[0]) dir = 1;
        else if(nums[1] < nums[0]) dir = -1;
        
        for(var i=2; i<n; i++){
            if(nums[i] > nums[i-1]){
                if(dir == -1) count++;  // valley found
                dir = 1;
            }
            else if(nums[i] < nums[i-1]){
                if(dir == 1) count++;   // hill found
                dir = -1;
            }
        }
        
        return count;
    }
}