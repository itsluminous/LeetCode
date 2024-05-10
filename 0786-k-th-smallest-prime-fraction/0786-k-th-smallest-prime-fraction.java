class Solution {
    public int[] kthSmallestPrimeFraction(int[] arr, int k) {
        var n = arr.length;
        var pq = new PriorityQueue<int[]>(Comparator.comparingDouble(ar -> (double)ar[0]/ar[1]));

        for(var i=0; i<n; i++)
            for(var j=i+1; j<n; j++)
                pq.offer(new int[]{arr[i], arr[j]});
        
        while(k-- > 1) pq.poll();
        return pq.poll();
    }
}