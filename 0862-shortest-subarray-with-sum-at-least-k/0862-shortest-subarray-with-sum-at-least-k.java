class Solution {
    public int shortestSubarray(int[] nums, int k) {
        int n = nums.length, shortest = n+1;
        
        // calculate prefix sum
        // in prefix sum, we know that sum of nums from l to r is pre[r] - pre[l]
        var pre = new long[n+1];
        for(var i=0; i<n; i++)
            pre[i+1] = pre[i] + nums[i];

        // create an increasing double ended queue
        Deque<Integer> dq = new ArrayDeque<>();
        for(var i=0; i<=n; i++){
            // if sum till i >= k, then try to reduce the array size from left side, to get smallest array
            while(dq.size() > 0 && pre[i] - pre[dq.getFirst()] >= k){
                shortest = Math.min(shortest, i - dq.getFirst());
                dq.pollFirst();
            }
            
            // to keep the dequeue in increasing order, remove elements from right which are >= pre[i]
            // the removed nums are useless to us because they will only yield longer subarrays
            while(dq.size() > 0 && pre[i] <= pre[dq.getLast()])
                dq.pollLast();
            
            // append the current index in dequeue
            dq.addLast(i);
        }

        if(shortest == n+1) return -1;
        return shortest;
    }
}