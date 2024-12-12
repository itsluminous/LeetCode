class Solution {
    public long pickGifts(int[] gifts, int k) {
        var pq = new PriorityQueue<Integer>((a, b) -> b - a);
        for(var g : gifts) pq.offer(g);

        while(k-- > 0){
            var num = pq.poll();
            num = (int) Math.sqrt(num);
            pq.offer(num);
        }

        long remaining = 0;
        while(!pq.isEmpty()) remaining += pq.poll();
        return remaining;
    }
}