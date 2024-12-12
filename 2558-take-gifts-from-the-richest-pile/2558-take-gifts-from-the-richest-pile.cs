public class Solution {
    public long PickGifts(int[] gifts, int k) {
        var pq = new PriorityQueue<int, int>();
        foreach(var g in gifts) pq.Enqueue(g, -g);

        while(k-- > 0){
            var num = pq.Dequeue();
            num = (int) Math.Sqrt(num);
            pq.Enqueue(num, -num);
        }

        long remaining = 0;
        while(pq.Count > 0) remaining += pq.Dequeue();
        return remaining;
    }
}