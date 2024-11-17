public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length, shortest = n+1;
        
        // calculate prefix sum
        // in prefix sum, we know that sum of nums from l to r is pre[r] - pre[l]
        var pre = new long[n+1];
        for(var i=0; i<n; i++)
            pre[i+1] = pre[i] + nums[i];

        // create an increasing double ended queue
        var dq = new LinkedList<int>();
        for(var i=0; i<=n; i++){
            // if sum till i >= k, then try to reduce the array size from left side, to get smallest array
            while(dq.Count > 0 && pre[i] - pre[dq.First.Value] >= k){
                shortest = Math.Min(shortest, i - dq.First.Value);
                dq.RemoveFirst();
            }
            
            // to keep the dequeue in increasing order, remove elements from right which are >= pre[i]
            // the removed nums are useless to us because they will only yield longer subarrays
            while(dq.Count > 0 && pre[i] <= pre[dq.Last.Value])
                dq.RemoveLast();
            
            // append the current index in dequeue
            dq.AddLast(i);
        }

        if(shortest == n+1) return -1;
        return shortest;
    }
}