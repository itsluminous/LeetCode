// Simplified
public class Solution {
    public int MaxProduct(int[] nums) {
        var max = nums[0];
        for(int i=1, currMax=max, currMin=max; i<nums.Length; i++){
            // multiplied by a negative makes big number smaller, small number bigger
            // so we redefine the extremums by swapping them
            if(nums[i] < 0){
                var temp = currMax;
                currMax = currMin;
                currMin = temp;
            }
            
            currMax = Math.Max(currMax*nums[i], nums[i]);
            currMin = Math.Min(currMin*nums[i], nums[i]);
            max = Math.Max(max, currMax);
        }
        
        return max;
    }
}

// Naive
public class Solution1 {
    public int MaxProduct(int[] nums) {
        int negProduct = 0, posProduct = 0, max=int.MinValue, n = nums.Length;
        
        if(n == 1) return nums[0];   // input like [-5] should not return 0
        
        for(var i=0; i<n; i++){
            if(nums[i] == 0){
                max = Math.Max(max, posProduct);
                negProduct = 0;
                posProduct = 0;
            }
            else if(nums[i] < 0){
                var curr = Math.Max(nums[i], negProduct*nums[i]);
                negProduct = Math.Min(nums[i], posProduct*nums[i]);
                posProduct = curr;
            }
            else{
                posProduct = Math.Max(nums[i], posProduct*nums[i]);
                negProduct = Math.Min(nums[i], negProduct*nums[i]);
            }
            max = Math.Max(max, posProduct);
        }
        
        return Math.Max(max, posProduct);
    }
}
