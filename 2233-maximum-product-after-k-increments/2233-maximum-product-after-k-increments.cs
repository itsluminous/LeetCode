public class Solution {
    public int MaximumProduct(int[] nums, int k) {
        var modulo = 1_000_000_007;
        var pq = new PriorityQueue<long, long>(nums.Select(x => ((long)x, (long)x)));
        
        while(k != 0){
            if(pq.Peek() == long.MaxValue) break;   // increasing any further is senseless
            
            // increase the smallest element by one
            var top = pq.Dequeue();
            top++; k--;
            pq.Enqueue(top, top);
        }
        
        // result is product of all numbers in queue
        long result = 1;
        while(pq.Count > 0)
            result = (result * pq.Dequeue())% modulo;
        
        return (int)result;
    }
}