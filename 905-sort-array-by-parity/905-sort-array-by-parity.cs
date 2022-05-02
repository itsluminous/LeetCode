// Better complexity
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int start = 0, end = nums.Length-1;
        while(start < end){
            // if num at start idx is odd and end idx is even, swap
            if(nums[start] % 2 > nums[end] % 2){
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }
            
            // if num at start idx is even, then check next num
            if(nums[start] % 2 == 0) start++;
            // if num at end idx is odd, then search for next even num on left side
            if(nums[end] % 2 == 1) end--;
        }
        
        return nums;
    }
}

// Accepted
public class Solution1 {
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