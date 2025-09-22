public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        int maxFreq = 0, maxFreqCount = 0;

        var freq = new int[101];
        foreach(var num in nums){
            freq[num]++;
            
            if(freq[num] > maxFreq)
                maxFreq = maxFreqCount = freq[num];
            else if(freq[num] == maxFreq)
                maxFreqCount += freq[num];
        }

        return maxFreqCount;
    }
}