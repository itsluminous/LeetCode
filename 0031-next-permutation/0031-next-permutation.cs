public class Solution {
    public void NextPermutation(int[] nums) {
        var n = nums.Length;

        // find the first pair from right side where nums[i+1] > nums[i]
        var decreasingPair = n-2;
        while(decreasingPair >= 0 && nums[decreasingPair + 1] <= nums[decreasingPair])
            decreasingPair--;
        
        if(decreasingPair >= 0){
            // find out the num of right side of this which is just bigger than it
            var justBigger = n-1;
            while(nums[justBigger] <= nums[decreasingPair])
                justBigger--;
            
            // swap the two numbers
            (nums[justBigger], nums[decreasingPair]) = (nums[decreasingPair], nums[justBigger]);
        }

        // reverse all numbers after `decreasingPair` idx (so that they now become ascending slope)
        int left=decreasingPair+1, right = n-1;
        while(left < right){
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }
    }
}