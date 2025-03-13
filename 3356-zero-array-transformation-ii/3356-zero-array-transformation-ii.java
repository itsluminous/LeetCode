class Solution {
    public int minZeroArray(int[] nums, int[][] queries) {
        int n = nums.length, q = queries.length;
        var decr = new int[n];  // prefix sum of how much can be decremented at each index
        var currMaxDecr = 0;    // max decr allowed currently
        var k = 0;

        for(var i=0; i<n; i++){
            // keep using queries till we cannot qualify current num
            while(nums[i] > currMaxDecr + decr[i]){
                if(k == q) return -1;   // exhausted all queries, cannot make it 0

                // read k-th query
                int l = queries[k][0], r = queries[k][1], val = queries[k][2];
                k++;
                
                // if the query ends before curr idx, it is useless
                // if the query start after curr idx, then it is useless now, but may be used later
                if(r < i) continue;

                // apply the k-th query (line sweeping algo)
                decr[Math.max(l, i)] += val;
                if(r < n-1) decr[r + 1] -= val;
            }
            currMaxDecr += decr[i];
        }
        
        return k;
    }
}