// keep a count of how many times we are flipping, and also track which all indexes are flipped
// using these two info, we can figure out if curr index needs to be flipped to make 1 or not
public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        // currFlipCount = how many times curr bit was flipped due to prev windows of length k
        int n = nums.Length, totalFlipCount = 0, currFlipCount = 0;
        var isFlippedAt = new int[n];     // 1 = index was flipped, 0 = not flipped

        for(var i=0; i<n; i++){
            // index i is out of scope for window starting at index (i-k)
            if(i >= k) currFlipCount -= isFlippedAt[i - k];

            // if curr num is 1, and curr index was flipped even times in past windows, then nothing has changed
            // if curr num is 0, and curr index was flipped odd times in past windows, then it is already 1
            if((nums[i] == 1 && (currFlipCount & 1) == 0) || 
               (nums[i] == 0 && (currFlipCount & 1) == 1))
                continue;

            // if curr num is 1, and curr index was flipped odd times in past windows, then flip to make it 1
            // if curr num is 0, and curr index was flipped even times in past windows, then flip to make it 1
            if((nums[i] == 1 && (currFlipCount & 1) == 1) || 
               (nums[i] == 0 && (currFlipCount & 1) == 0)){
                if(i + k > n) return -1;    // the flip window has to be k, can't be less than that
                isFlippedAt[i] = 1;         // flip curr idx to make it 1
                currFlipCount++;
                totalFlipCount++;
            }
        }

        return totalFlipCount;
    }
}