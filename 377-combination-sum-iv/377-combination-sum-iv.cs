// TOP Down : find out how many ways we can reach target when I have to pick each number only once
// then how to reach the prev state, and then prev state etc.
public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var comb = new int[target + 1];
        comb[0] = 1;
        for(var i=1; i<comb.Length; i++)            // for each possible target
            for(var j=0; j<nums.Length; j++)        // for each number given
                if(i - nums[j] >= 0)                // if it is a valid index in comb array
                    comb[i] += comb[i - nums[j]];   // then update ways to reach this target
        
        return comb[target];
    }
}