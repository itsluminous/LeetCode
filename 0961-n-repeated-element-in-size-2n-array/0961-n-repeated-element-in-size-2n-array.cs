public class Solution {
    public int RepeatedNTimes(int[] nums) {
        var freq = new int[10001];
        foreach(var num in nums){
            freq[num]++;
            if(freq[num] == 2) return num;
        }
        return -1;
    }
}