class Solution {
    public int repeatedNTimes(int[] nums) {
        var freq = new int[10001];
        for(var num : nums){
            freq[num]++;
            if(freq[num] == 2) return num;
        }
        return -1;
    }
}