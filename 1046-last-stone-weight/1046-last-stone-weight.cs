public class Solution {
    public int LastStoneWeight(int[] stones)
    {
        // To avoid creating a custom comparer to order by desc, we just revert priorities (-x).
        var pq = new PriorityQueue<int, int>(stones.Select(x => (x, -x)));
        while (pq.Count > 1){
            var diff = Math.Abs(pq.Dequeue() - pq.Dequeue());
            if (diff != 0)
                pq.Enqueue(diff, -diff);
        }

        return (pq.Count == 0) ? 0 : pq.Peek();
    }
}