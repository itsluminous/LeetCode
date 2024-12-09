class Solution {
    public boolean[] isArraySpecial(int[] nums, int[][] queries) {
        var n = nums.length;
        
        // prefix array of how many have same parity till given idx
        var pre = new int[n];
        for(var i=1; i<n; i++){
            if((nums[i] & 1) == (nums[i-1] & 1))
                pre[i] = pre[i-1] + 1;
            else
                pre[i] = pre[i-1];
        }

        // figure out ans based on prefix array
        var q = queries.length;
        var ans = new boolean[q];
        for(var i=0; i<q; i++){
            int start = queries[i][0], end = queries[i][1];
            if(pre[start] == pre[end])
                ans[i] = true;
        }
        
        return ans;
    }
}