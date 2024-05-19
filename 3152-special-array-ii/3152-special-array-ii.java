class Solution {
    public boolean[] isArraySpecial(int[] nums, int[][] queries) {
        var n = queries.length;
        var ans = new boolean[n];

        // calculate how many bad pairs we have seen till now
        var bad = new int[nums.length];
        for(int i=1, j=0; i<nums.length; i++){
            if((nums[i] & 1) == (nums[i-1] & 1))  bad[i] = ++j;
            else bad[i] = j;
        }

        // for each query, if the count of bad pairs at start index is same as that at end index, then its special
        for(var i=0; i<n; i++){
            int start = queries[i][0], end = queries[i][1];
            if(bad[start] == bad[end]) ans[i] = true;
        }

        return ans;
    }
}