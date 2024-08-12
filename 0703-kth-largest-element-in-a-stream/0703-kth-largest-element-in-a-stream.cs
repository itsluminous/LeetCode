public class KthLargest {
    PriorityQueue<int, int> minHeap;
    int k;

    public KthLargest(int k, int[] nums) {
        minHeap = new(nums.Select(x => (x, x)));
        this.k = k;

        while(minHeap.Count > k) minHeap.Dequeue();
    }
    
    public int Add(int val) {
        minHeap.Enqueue(val, val);
        if(minHeap.Count > k) minHeap.Dequeue();
        return minHeap.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */