public class Solution {
    public long MaxKelements(int[] nums, int k) {
        var maxHeap = new PriorityQueue<double, int>();
        foreach(var num in nums) maxHeap.Enqueue(1.0 * num, -num);

        long score = 0;
        for(var i=0; i<k; i++){
            var num = maxHeap.Dequeue();
            score += (int)num;

            num = (int)Math.Ceiling(num / 3);
            maxHeap.Enqueue(num, (int)-num);
        }

        return score;
    }
}