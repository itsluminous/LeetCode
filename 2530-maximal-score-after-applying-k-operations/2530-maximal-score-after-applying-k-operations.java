class Solution {
    public long maxKelements(int[] nums, int k) {
        var maxHeap = new PriorityQueue<Integer>((n1, n2) -> n2 - n1);
        for(var num : nums) maxHeap.offer(num);

        long score = 0;
        for(var i=0; i<k; i++){
            var num = maxHeap.poll();
            score += num;

            maxHeap.offer((int)Math.ceil((double)num / 3));
        }

        return score;
    }
}