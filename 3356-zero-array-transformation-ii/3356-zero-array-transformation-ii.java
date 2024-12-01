class Solution {
    public int minZeroArray(int[] nums, int[][] queries) {
        int n = nums.length, q = queries.length, k = 0, currSum = 0;
        var prefixSum = new int[n+1];

        for(var i=0; i<n; i++){
            // keep using queries till we cannot qualify current num
            while(currSum + prefixSum[i] < nums[i]){
                if(k == q) return -1;    // exhausted all queries

                int left = queries[k][0], right = queries[k][1], val = queries[k][2];
                k++;

                // if the query ends before curr idx, it is useless
                // if the query start after curr idx, then it is useless now, but may be used later
                if(right < i) continue;

                // update prefixSum with line sweeping algo (same as 3355. Zero Array Transformation I)
                prefixSum[Math.max(left, i)] += val;
                prefixSum[right+1] -= val;
            }
            currSum += prefixSum[i];
        }
        
        return k;
    }
}