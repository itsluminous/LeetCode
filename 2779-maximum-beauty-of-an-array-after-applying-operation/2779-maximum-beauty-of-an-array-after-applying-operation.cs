public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        var maxVal = nums.Max();

        // prefix sum array to know when a range starts and when it ends
        var pre = new int[maxVal+1];
        foreach(var num in nums){
            int start = Math.Max(num-k, 0), end = num + k + 1;
            pre[start]++;
            if(end <= maxVal)
                pre[end]--;
        }
        
        // find the index with most overlap
        int ans = 0, curr = 0;
        foreach(var num in pre){
            curr += num;
            ans = Math.Max(ans, curr);
        }
        
        return ans;
    }
}