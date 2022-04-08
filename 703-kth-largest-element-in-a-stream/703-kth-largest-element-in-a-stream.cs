public class KthLargest {
    int kk = 0;
    PriorityQueue<int, int> pq;

    public KthLargest(int k, int[] nums) {
        pq = new PriorityQueue<int, int>(nums.Select(x => (x, x))); // sort ascending
        kk = k;
        
        // remove all elements which are more than k
        while(pq.Count > kk) pq.Dequeue();
    }
    
    public int Add(int val) {
        pq.Enqueue(val, val);
        if(pq.Count > kk) pq.Dequeue();
        return pq.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */