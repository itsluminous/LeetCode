public class Solution {
    public void NextPermutation(int[] nums) {
        var n = nums.Length;
        if(n <= 1) return;
        
        var firstDecreasing = n-2;
        while(firstDecreasing >= 0 && nums[firstDecreasing+1] <= nums[firstDecreasing])
            firstDecreasing--;
        
        if(firstDecreasing >= 0){
            var nextHighest = n-1;
            while(nums[nextHighest] <= nums[firstDecreasing])
                nextHighest--;
            Swap(nums, firstDecreasing, nextHighest);
        }
        Reverse(nums, firstDecreasing+1);
    }
    
    private void Swap(int[] nums, int i, int j){
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    private void Reverse(int[] nums, int start){
        int i = start, j = nums.Length-1;
        while(i < j)
            Swap(nums, i++, j--);
    }
}