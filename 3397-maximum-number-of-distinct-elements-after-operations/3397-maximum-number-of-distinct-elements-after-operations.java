class Solution {
    public int maxDistinctElements(int[] nums, int k) {
        Arrays.sort(nums);
        var ans = 0;
        var prev = Integer.MIN_VALUE;
        for(var num : nums){
            var curr = Math.min(Math.max(prev + 1, num - k), num + k);
            if(curr > prev){
                ans++;
                prev = curr;
            }
        }
        return ans;
    }
}