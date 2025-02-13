class Solution {
    public int minOperations(int[] nums, int k) {
        var op = 0;
        var minHeap = new PriorityQueue<Long>();
        for(var num : nums)
            minHeap.offer((long)num);

        var num = minHeap.poll();
        while(num < k){
            var next = 2 * num + minHeap.poll();
            minHeap.offer(next);
            op++;
            
            num = minHeap.poll();
        }
        
        return op;
    }
}