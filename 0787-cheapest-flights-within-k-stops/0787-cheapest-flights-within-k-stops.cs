// BFS - O(n + edges)
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // make graph
        var adj = new List<int[]>[n];
        for(var i = 0; i < n; i++)
            adj[i] = new List<int[]>();

        foreach(var edge in flights)
            adj[edge[0]].Add([edge[1], edge[2]]);

        // initialize cost
        var minCost = new int[n];
        Array.Fill(minCost, int.MaxValue);
        minCost[src] = 0;

        // initialize queue for BFS
        var queue = new Queue<int[]>();
        queue.Enqueue([src, 0]); // airport, cost

        // BFS
        for(var stops = 0; stops <= k && queue.Count > 0; stops++) {
            for(var i = queue.Count; i > 0; i--) {
                var airportCost = queue.Dequeue();
                int airport = airportCost[0], cost = airportCost[1];

                foreach(var next in adj[airport]) {
                    if(minCost[next[0]] > cost + next[1]) {
                        minCost[next[0]] = cost + next[1];
                        queue.Enqueue([next[0], cost + next[1]]);
                    }
                }
            }
        }

        return minCost[dst] == int.MaxValue ? -1 : minCost[dst];
    }
}

// Accepted - Bellman Ford - O(n * k)
public class SolutionBF {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var minCost = new int[n];
        Array.Fill(minCost, int.MaxValue);
        minCost[src] = 0;

        for(var i = 0; i <= k; i++) {
            // clone so that the cost updated in i-th stop loop is used only in i+1 th stop loop
            int[] costCopy = (int[])minCost.Clone();
            foreach(var flight in flights) {
                int start = flight[0], end = flight[1], price = flight[2];
                if(minCost[start] == int.MaxValue) continue;
                costCopy[end] = Math.Min(costCopy[end], price + minCost[start]);
            }
            minCost = costCopy;
        }

        return minCost[dst] == int.MaxValue ? -1 : minCost[dst];
    }
}

// TLE - Dijkastra - O(n ^ k)
public class SolutionDj {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // make graph
        var adj = new List<int[]>[n];
        for(var i = 0; i < n; i++)
            adj[i] = new List<int[]>();

        foreach(var edge in flights)
            adj[edge[0]].Add([edge[1], edge[2]]);

        // initialize pq for Dijkstra
        var queue = new PriorityQueue<int[], int>();
        queue.Enqueue([src, 0, 0], 0); // airport, cost, stops used

        while(queue.Count > 0) {
            var airportCost = queue.Dequeue();
            int airport = airportCost[0], cost = airportCost[1], kk = airportCost[2];
            if(airport == dst) return cost;
            if(kk == k + 1) continue; // exhausted all stops

            foreach(var next in adj[airport])
                queue.Enqueue([next[0], cost + next[1], kk + 1], cost + next[1]);
        }

        return -1;
    }
}