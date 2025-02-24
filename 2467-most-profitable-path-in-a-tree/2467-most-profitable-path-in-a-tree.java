class Solution {
    public int mostProfitablePath(int[][] edges, int bob, int[] amount) {
        var n = edges.length + 1;
        var adj = makeGraph(edges);
        var bobSteps = bobTraversal(adj, bob, 0);   // in how many steps bob visited each node in shortest path
        return aliceTraversal(adj, amount, bobSteps, 0);
    }

    private int aliceTraversal(List<Integer>[] adj, int[] amount, int[] bobSteps, int start){
        var n = adj.length;
        var maxProfit = Integer.MIN_VALUE;

        var profit = new int[n];    // max amount we can earn at any node
        Arrays.fill(profit, Integer.MIN_VALUE);

        profit[start] = amount[start];
        if(bobSteps[start] == 0)
            profit[start] /= 2;

        var visited = new boolean[n];
        visited[start] = true;
        
        // bfs
        Queue<Integer> queue = new LinkedList<>();
        queue.offer(start);

        for(var steps = 1; !queue.isEmpty(); steps++){
            for(var i = queue.size(); i > 0; i--){
                var node = queue.poll();
                // if a terminal node
                if(node != start && adj[node].size() == 1){
                    maxProfit = Math.max(maxProfit, profit[node]);
                    continue;
                }
                
                for(var next : adj[node]){
                    if(visited[next]) continue;

                    var p = amount[next];
                    if(bobSteps[next] == steps) p /= 2;
                    if(bobSteps[next] < steps) p = 0;

                    profit[next] = p + profit[node];
                    queue.offer(next);
                    visited[next] = true;
                }
            }
        }

        return maxProfit;
    }

    private int[] bobTraversal(List<Integer>[] adj, int start, int dest){
        var n = adj.length;  
        var distance = new int[n];  // distance from start node
        var parent = new int[n];

        // bfs
        Queue<Integer> queue = new LinkedList<>();
        queue.offer(start);

        while(!queue.isEmpty()){
            var node = queue.poll();
            if(node == dest) break;

            for(var next : adj[node]){
                if(next == start || distance[next] > 0) continue;   // if visited
                parent[next] = node;
                distance[next] = distance[node] + 1;
                queue.offer(next);
            }
        }

        // find out how many steps we took for each node in shortest path
        var steps = new int[n];
        while(dest != start){
            steps[dest] = distance[dest];
            dest = parent[dest];
        }

        // mark remaining nodes as unvisited
        for(var i = 0; i < n; i++){
            if(i == start || steps[i] > 0) continue;
            steps[i] = Integer.MAX_VALUE;
        }

        return steps;
    }

    private List<Integer>[] makeGraph(int[][] edges){
        var n = edges.length + 1;
        List<Integer>[] adj = new List[n];
        for(var i = 0; i < n; i++)
            adj[i] = new ArrayList<>();
        
        for(var edge : edges){
            int n1 = edge[0], n2 = edge[1];
            adj[n1].add(n2);
            adj[n2].add(n1);
        }

        return adj;
    }
}
