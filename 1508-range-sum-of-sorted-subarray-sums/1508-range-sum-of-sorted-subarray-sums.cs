public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        var pq = new PriorityQueue<(int,int), int>();    // minHeap
        for(var i=0; i<n; i++)
            pq.Enqueue((nums[i], i+1), nums[i]);
        
        int total = 0, MOD = 1_000_000_007;
        for(var i=1; i<=right; i++){
            var (sum, next) = pq.Dequeue();

            // if we popped enough from left side, we can start adding this to total
            if(i >= left)
                total = (total + sum) % MOD;
            
            // if we can add more to this number, then add it
            if(next < n){
                sum += nums[next++];
                pq.Enqueue((sum, next), sum);
            }
        }

        return total;

    }
}