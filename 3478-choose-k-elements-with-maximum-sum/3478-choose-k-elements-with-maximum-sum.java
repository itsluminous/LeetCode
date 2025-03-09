class Solution {
    public long[] findMaxSum(int[] nums1, int[] nums2, int k) {
        var n = nums1.length;
        var ans = new long[n];

        // combine nums1 & nums2 into a 2d array : [idx, nums1, nums2]
        var idxNums = new int[n][3];
        for(var i=0; i<n; i++)
            idxNums[i] = new int[]{i, nums1[i], nums2[i]};
        Arrays.sort(idxNums, (n1, n2) -> n1[1] - n2[1]);

        long currSum = 0;
        var pq = new PriorityQueue<Integer>();
        for(var i=0; i<n; i++){
            int idx = idxNums[i][0], n1 = idxNums[i][1], n2 = idxNums[i][2];
            // if curr num is same as prev, copy result
            if(i > 0 && n1 == idxNums[i-1][1])
                ans[idx] = ans[idxNums[i-1][0]];
            else
                ans[idx] = currSum;
            currSum += n2;
            
            // maintain sum of last k elements only
            pq.offer(n2);
            if(pq.size() > k)
                currSum -= pq.poll();
        }

        return ans;
    }
}