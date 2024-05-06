public class Solution {
    public int CountMatchingSubarrays(int[] nums, int[] pattern) {
        FormatNumsArray(nums);                  // convert the nums array to -1, 0, 1 format
        var lps = ComputeLPS(pattern);          // Build longest prefix suffix array for KMP
        return KMPSearch(nums, pattern, lps);   // now check how many times pattern matches
    }

    private void FormatNumsArray(int[] nums){
        var n = nums.Length;
        for(var i=0; i<n-1; i++){
            if(nums[i] == nums[i+1]) nums[i] = 0;
            else if(nums[i] > nums[i+1]) nums[i] = -1;
            else nums[i] = 1;
        }
        nums[n-1] = 9;   // any arbitrary number other than -1, 0, 1
    }

    private int[] ComputeLPS(int[] pattern){
        var n = pattern.Length;
        var lps = new int[n];
        int len=0, i=1;     // len is the current longest prefix suffix and i is curr index in pattern
        
        while(i < n){
            if(pattern[i] == pattern[len]){
                len++;
                lps[i] = len;
                i++;
            }
            // two possibilities when there is no match
            else if(len == 0){
                lps[i] = len;   // basically, lps[i] is set to 0
                i++;
            }
            else{
                len = lps[len-1];
            }
        }

        return lps;
    }

    private int KMPSearch(int[] nums, int[] pattern, int[] lps){
        int nLen = nums.Length, pLen = pattern.Length;
        int nIdx = 0, pIdx = 0;

        var matchCount = 0;
        while(nIdx < nLen){
            if(nums[nIdx] == pattern[pIdx]){
                nIdx++;
                pIdx++;
            }

            // if we reached end of pattern array, then it was a match
            if(pIdx == pLen){
                matchCount++;
                pIdx = lps[pIdx-1];
            }
            else if(nIdx < nLen && nums[nIdx] != pattern[pIdx]){
                // this is where KMP differs vs brute force. 
                // We will skip comparison for 0 to lps[pIdx-1] characters in pattern
                if(pIdx != 0) pIdx = lps[pIdx-1];
                else nIdx++;
            }
        }

        return matchCount;
    }
}