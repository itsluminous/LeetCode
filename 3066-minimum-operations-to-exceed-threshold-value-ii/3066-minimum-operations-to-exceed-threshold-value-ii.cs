public class Solution {
    public int MinOperations(int[] nums, int k) {
        var op = 0;
        var minHeap = new PriorityQueue<long, long>();
        foreach(var nm in nums)
            minHeap.Enqueue(nm, nm);

        var num = minHeap.Dequeue();
        while(num < k){
            var next = 2 * num + minHeap.Dequeue();
            minHeap.Enqueue(next, next);
            op++;
            
            num = minHeap.Dequeue();
        }
        
        return op;
    }
}