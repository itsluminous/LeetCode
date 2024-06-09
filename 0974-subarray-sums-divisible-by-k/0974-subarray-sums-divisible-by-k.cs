public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int n = nums.Length, count = 0;
        var freq = new int[k];
        freq[0] = 1;

        var curr = 0;
        foreach(var num in nums){
            curr += num;
            curr %= k;
            if(curr < 0) curr += k;     // we need positive remainder

            count += freq[curr];
            freq[curr]++;
        }

        return count;
    }
}