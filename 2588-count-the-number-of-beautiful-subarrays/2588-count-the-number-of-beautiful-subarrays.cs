public class Solution {
    public long BeautifulSubarrays(int[] nums) {
        long count = 0;
        var xorFreq = new Dictionary<int, int>();
        xorFreq[0] = 1;

        var xor = 0;
        foreach(var num in nums){
            xor ^= num;
            var freq = xorFreq.ContainsKey(xor) ? xorFreq[xor] : 0;
            count += freq;
            xorFreq[xor] = 1 + freq;
        }

        return count;
    }
}