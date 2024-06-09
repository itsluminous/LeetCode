class Solution {
    public int subarraysDivByK(int[] nums, int k) {
        int n = nums.length, count = 0;
        var freq = new int[k];
        freq[0] = 1;

        var curr = 0;
        for(var num : nums){
            curr += num;
            curr %= k;
            if(curr < 0) curr += k;     // we need positive remainder

            count += freq[curr];
            freq[curr]++;
        }

        return count;
    }
}