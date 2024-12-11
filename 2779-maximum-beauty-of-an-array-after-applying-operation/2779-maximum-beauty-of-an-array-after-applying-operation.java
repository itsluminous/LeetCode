class Solution {
    public int maximumBeauty(int[] nums, int k) {
        var maxVal = Arrays.stream(nums).max().getAsInt();

        // prefix sum array to know when a range starts and when it ends
        var pre = new int[maxVal+1];
        for(var num : nums){
            int start = Math.max(num-k, 0), end = num + k + 1;
            pre[start]++;
            if(end <= maxVal)
                pre[end]--;
        }
        
        // find the index with most overlap
        int ans = 0, curr = 0;
        for(var num : pre){
            curr += num;
            ans = Math.max(ans, curr);
        }
        
        return ans;
    }
}