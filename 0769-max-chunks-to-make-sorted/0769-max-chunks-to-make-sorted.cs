public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        // idea is that till index i, if I have found all numbers till i, I can split
        // to check if I found all nums, I can just keep track of max num found till curr index
        // if max num found matches that index, it means I found all nums
        int maxNum = 0, chunks = 0;
        for(var i=0; i<arr.Length; i++){
            maxNum = Math.Max(maxNum, arr[i]);
            if(maxNum == i)
                chunks++;
        }

        return chunks;
    }
}

// accepted - using bitmask
public class SolutionBM {
    public int MaxChunksToSorted(int[] arr) {
        // idea is that till index i, if I have found all numbers till i, I can split
        // to check if I found all nums, I can use bitmask to track found nums
        int mask = 0, chunks = 0;
        for(var i=0; i<arr.Length; i++){
            mask |= (1 << arr[i]);
            var expected = (1 << (i + 1)) - 1;       // expected for i = 2 would be 000111, and so on
            if((mask ^ expected) == 0)
                chunks++;
        }

        return chunks;
    }
}