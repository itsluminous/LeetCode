public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        var endIdx = nums.Length-1;
        for(var startIdx=0; startIdx<endIdx; startIdx++){
            // nothing to do if curr number is even. proceed to next num
            if(nums[startIdx] % 2 == 0) continue;
            
            // find the next even number from back side and swap curr odd with it
            while(endIdx > startIdx){
                if(nums[endIdx] % 2 == 0) break;
                else endIdx--;
            }
            
            // if no even num was found, then we are done
            if(endIdx == startIdx) break;
            
            // swap curr num with the even number we found
            var temp = nums[startIdx];
            nums[startIdx] = nums[endIdx];
            nums[endIdx] = temp;
        }
        
        return nums;
    }
}