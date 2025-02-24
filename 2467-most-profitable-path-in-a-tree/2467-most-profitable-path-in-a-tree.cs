public class Solution {
    public int MostProfitablePath(int[][] edges, int bob, int[] amount) {
        var n = edges.Length + 1;
        var adj = MakeGraph(edges);
        var bobSteps = BobTraversal(adj, bob, 0);   // in how many steps bob visited each node in shortest path
        return AliceTraversal(adj, amount, bobSteps, 0);
    }

    private int AliceTraversal(List<int>[] adj, int[] amount, int[] bobSteps, int start){
        var n = adj.Length;
        var maxProfit = int.MinValue;

        var profit = new int[n];    // max amount we can earn at any node
        for(var i=0; i<n; i++)
            profit[i] = int.MinValue;

        profit[start] = amount[start];
        if(bobSteps[start] == 0)
            profit[start] /= 2;

        var visited = new bool[n];
        visited[start] = true;
        
        // bfs
        var queue = new Queue<int>();
        queue.Enqueue(start);

        for(var steps = 1; queue.Count > 0; steps++){
            for(var i=queue.Count; i>0; i--){
                var node = queue.Dequeue();
                // if a terminal node
                if(node != start && adj[node].Count == 1){
                    maxProfit = Math.Max(maxProfit, profit[node]);
                    continue;
                }
                
                foreach(var next in adj[node]){
                    if(visited[next]) continue;

                    var p = amount[next];
                    if(bobSteps[next] == steps) p /= 2;
                    if(bobSteps[next] < steps) p = 0;

                    profit[next] = p + profit[node];
                    queue.Enqueue(next);
                    visited[next] = true;
                }
            }
        }

        return maxProfit;
    }

    private int[] BobTraversal(List<int>[] adj, int start, int dest){
        var n = adj.Length;  
        var distance = new int[n];  // distance from start node
        var parent = new int[n];

        // bfs
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while(queue.Count > 0){
            var node = queue.Dequeue();
            if(node == dest) break;

            foreach(var next in adj[node]){
                if(next == start || distance[next] > 0) continue;   // if visited
                parent[next] = node;
                distance[next] = distance[node] + 1;
                queue.Enqueue(next);
            }
        }

        // find out how many steps we took for each node in shortest path
        var steps = new int[n];
        while(dest != start){
            steps[dest] = distance[dest];
            dest = parent[dest];
        }

        // mark remaining nodes as unvisited
        for(var i=0; i<n; i++){
            if(i == start || steps[i] > 0) continue;
            steps[i] = int.MaxValue;
        }

        return steps;
    }

    private List<int>[] MakeGraph(int[][] edges){
        var n = edges.Length + 1;
        var adj = new List<int>[n];
        for(var i=0; i<n; i++)
            adj[i] = new List<int>();
        
        foreach(var edge in edges){
            int n1 = edge[0], n2 = edge[1];
            adj[n1].Add(n2);
            adj[n2].Add(n1);
        }

        return adj;
    }
}