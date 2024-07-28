class Solution {
    public int secondMinimum(int n, int[][] edges, int cost, int change) {
        var graph = buildGraph(n, edges);
        return bfs(graph, cost, change);
    }

    private int bfs(List<Integer>[] graph, int cost, int change){
        var n = graph.length - 1;
        int[] dist1 = new int[n+1], dist2 = new int[n+1];
        for(var i=0; i<=n; i++)
            dist1[i] = dist2[i] = -1;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{1, 1});
        dist1[1] = 0;

        while(!queue.isEmpty()){
            var val = queue.poll();
            int node = val[0], freq = val[1];
            if(graph[node].size() == 0) continue;

            var timeTaken = dist1[node];
            if(freq != 1) timeTaken = dist2[node];
            timeTaken = redGreen(timeTaken, cost, change);

            for(var next : graph[node]){
                if(dist1[next] == -1){
                    dist1[next] = timeTaken;
                    queue.offer(new int[]{next, 1});
                }
                else if(dist2[next] == -1 && dist1[next] != timeTaken){
                    if(next == n) return timeTaken;
                    dist2[next] = timeTaken;
                    queue.offer(new int[]{next, 2});
                }
            }
        }

        return 0;   // this will actually never reach
    }

    private int redGreen(int timeTaken, int cost, int change){
        if((timeTaken / change) % 2 == 0)
            return timeTaken + cost;
        var timeTakenDueToSignal = change * (timeTaken / change + 1);
        return cost + timeTakenDueToSignal;
    }

    private List<Integer>[] buildGraph(int n, int[][] edges){
        List<Integer>[] adjList = new List[n+1];
        for(var i=0; i<=n; i++) 
            adjList[i] = new ArrayList<>();

        for(var edge : edges){
            int src = edge[0], dest = edge[1];
            adjList[src].add(dest);
            adjList[dest].add(src);
        }

        return adjList;
    }
}