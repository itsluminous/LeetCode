class Solution {
    public int minSwaps(int[] nums) {
        int n = nums.length, n2 = 2 * n, totalOnes = 0;
        for(var num : nums) totalOnes += num;

        if(totalOnes <= 1) return 0;

        int maxOnesInWindow = 0, currOnes = 0;
        for(var i=0; i<n2; i++){
            currOnes += nums[i % n];
            // if left of window was one, then decrement
            if(i >= totalOnes && nums[(i - totalOnes) % n] == 1)
                currOnes--;
            maxOnesInWindow = Math.max(maxOnesInWindow, currOnes);
        }

        return totalOnes - maxOnesInWindow;
    }
}