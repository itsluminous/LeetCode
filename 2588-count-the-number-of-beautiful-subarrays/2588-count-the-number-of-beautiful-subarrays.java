class Solution {
    public long beautifulSubarrays(int[] nums) {
        long count = 0;
        var xorFreq = new HashMap<Integer, Integer>();
        xorFreq.put(0, 1);

        var xor = 0;
        for(var num : nums){
            xor ^= num;
            var freq = xorFreq.getOrDefault(xor, 0);
            count += freq;
            xorFreq.put(xor, 1 + freq);
        }

        return count;
    }
}