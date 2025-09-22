class Solution {
    public int maxFrequencyElements(int[] nums) {
        int maxFreq = 0, maxFreqCount = 0;

        var freq = new int[101];
        for(var num : nums){
            freq[num]++;
            
            if(freq[num] > maxFreq)
                maxFreq = maxFreqCount = freq[num];
            else if(freq[num] == maxFreq)
                maxFreqCount += freq[num];
        }

        return maxFreqCount;
    }
}