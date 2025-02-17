// BFS - O(n + edges)
class Solution {
    public int findCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // make graph
        List<int[]>[] adj = new List[n];
        for(var i=0; i<n; i++)
            adj[i] = new ArrayList<>();
        
        for(var edge : flights)
            adj[edge[0]].add(new int[]{edge[1], edge[2]});
        
        // initialize cost
        var minCost = new int[n];
        Arrays.fill(minCost, Integer.MAX_VALUE);
        minCost[src] = 0;

        // initialize queue for BFS
        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{src, 0}); // airport, cost

        // BFS
        for(var stops = 0; stops <= k && !queue.isEmpty(); stops++){
            for(var i=queue.size(); i>0; i--){
                var airportCost = queue.poll();
                int airport = airportCost[0], cost = airportCost[1];

                for(var next : adj[airport]){
                    if(minCost[next[0]] > cost + next[1]){
                        minCost[next[0]] = cost + next[1];
                        queue.offer(new int[]{next[0], cost + next[1]});
                    }
                }
            }
        }

        return minCost[dst] == Integer.MAX_VALUE ? -1 : minCost[dst];
    }
}

// Accepted - Bellman Ford - O(n * k)
class SolutionBF {
    public int findCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var minCost = new int[n];
        Arrays.fill(minCost, Integer.MAX_VALUE);
        minCost[src] = 0;

        for(var i=0; i<=k; i++){
            // clone so that the cost updated in i-th stop loop is used only in i+1 th stop loop
            int[] costCopy = Arrays.copyOf(minCost,n);
            for(var flight : flights){
                int start = flight[0], end = flight[1], price = flight[2];
                if(minCost[start] == Integer.MAX_VALUE) continue;
                costCopy[end] = Math.min(costCopy[end], price + minCost[start]);
            }
            minCost = costCopy;
        }
        
        return minCost[dst] == Integer.MAX_VALUE ? -1 : minCost[dst];
    }
}

// TLE - Dijkastra - O(n ^ k)
class SolutionDj {
    public int findCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // make graph
        List<int[]>[] adj = new List[n];
        for(var i=0; i<n; i++)
            adj[i] = new ArrayList<>();
        
        for(var edge : flights)
            adj[edge[0]].add(new int[]{edge[1], edge[2]});
        
        // initialize pq for Dijkastra
        Queue<int[]> queue = new PriorityQueue<>((n1, n2) -> n1[1] - n2[1]);
        queue.offer(new int[]{src, 0, 0}); // airport, cost, stops used

        while(!queue.isEmpty()){
            var airportCost = queue.poll();
            int airport = airportCost[0], cost = airportCost[1], kk = airportCost[2];
            if(airport == dst) return cost;
            if(kk == k+1) continue;   // exhausted all stops
            
            for(var next : adj[airport])
                queue.offer(new int[]{next[0], cost + next[1], kk + 1});
        }

        return -1;
    }
}