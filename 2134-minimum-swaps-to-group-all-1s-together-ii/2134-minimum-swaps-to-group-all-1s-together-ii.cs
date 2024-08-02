public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length, n2 = 2 * n, totalOnes = 0;
        foreach(var num in nums) totalOnes += num;

        if(totalOnes <= 1) return 0;

        int maxOnesInWindow = 0, currOnes = 0;
        for(var i=0; i<n2; i++){
            currOnes += nums[i % n];
            // if left of window was one, then decrement
            if(i >= totalOnes && nums[(i - totalOnes) % n] == 1)
                currOnes--;
            maxOnesInWindow = Math.Max(maxOnesInWindow, currOnes);
        }

        return totalOnes - maxOnesInWindow;
    }
}