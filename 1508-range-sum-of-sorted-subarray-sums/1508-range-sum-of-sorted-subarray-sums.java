class Solution {
    public int rangeSum(int[] nums, int n, int left, int right) {
        PriorityQueue<int[]> pq = new PriorityQueue<>((a,b) -> a[0] - b[0]);    // minHeap
        for(var i=0; i<n; i++)
            pq.offer(new int[]{nums[i], i+1});
        
        int total = 0, MOD = 1_000_000_007;
        for(var i=1; i<=right; i++){
            var top = pq.poll();

            // if we popped enough from left side, we can start adding this to total
            if(i >= left)
                total = (total + top[0]) % MOD;
            
            // if we can add more to this number, then add it
            if(top[1] < n){
                top[0] += nums[top[1]++];
                pq.offer(top);
            }
        }

        return total;
    }
}