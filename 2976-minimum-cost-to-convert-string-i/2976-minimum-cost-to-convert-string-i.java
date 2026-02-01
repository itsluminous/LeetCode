class Solution {
    public long minimumCost(String source, String target, char[] original, char[] changed, int[] cost) {
        // make graph
        List<int[]>[] adjList = new List[26];
        for(var i=0; i<26; i++) adjList[i] = new ArrayList<>();
        for(var i=0; i<original.length; i++)
            adjList[original[i] - 'a'].add(new int[]{changed[i] - 'a', cost[i]});
        
        // find shortest path for all characters
        long[][] minCost = new long[26][26];
        for(var i=0; i<26; i++)
            minCost[i] = dijkastra(i, adjList);
        
        // calculate total conversion cost
        long totalCost = 0;
        for(var i=0; i<source.length(); i++){
            if(source.charAt(i) == target.charAt(i)) continue;
            var currCost = minCost[source.charAt(i) - 'a'][target.charAt(i) - 'a'];
            if(currCost == -1) return -1;   // not possible
            totalCost += currCost;
        }

        return totalCost;
    }

    private long[] dijkastra(int start, List<int[]>[] adjList){
        var minCost = new long[26];
        Arrays.fill(minCost, -1);
        var pq = new PriorityQueue<long[]>(Comparator.comparingLong(a -> a[0]));
        pq.offer(new long[]{0, start});  // [distance, node]

        while(!pq.isEmpty()){
            var curr = pq.poll();
            int node = (int) curr[1];
            long dist = curr[0];
            if(minCost[node] != -1 && minCost[node] < dist) continue;

            for(var next : adjList[node]){
                int nd = next[0], wt = next[1];
                if(minCost[nd] == -1L || minCost[nd] > dist + wt){
                    minCost[nd] = dist + wt;
                    pq.offer(new long[]{minCost[nd], nd});
                }
            }
        }

        return minCost;
    }
}