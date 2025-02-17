// Accepted - Dijkastra
class Solution {
    public int networkDelayTime(int[][] times, int n, int k) {
        // make graph
        List<int[]>[] adj = new List[n + 1];
        for(var i = 0; i <= n; i++)
            adj[i] = new ArrayList<>();

        for(var edge : times)
            adj[edge[0]].add(new int[]{edge[1], edge[2]});

        // initialize cost
        var minTime = new int[n + 1];
        Arrays.fill(minTime, Integer.MAX_VALUE);
        minTime[k] = 0;
        minTime[0] = 0; // array is 1-indexed, so this should not be counted later

        // initialize priority queue for Dijkstra
        PriorityQueue<int[]> queue = new PriorityQueue<>(Comparator.comparingInt(a -> a[1]));
        queue.offer(new int[]{k, 0}); // node, time

        while (!queue.isEmpty()) {
            var nodeTime = queue.poll();
            int node = nodeTime[0], cost = nodeTime[1];
            if (minTime[node] < cost) continue;  // found better path already

            for(var next : adj[node]) {
                if (minTime[next[0]] > cost + next[1]) {
                    minTime[next[0]] = cost + next[1];
                    queue.offer(new int[]{next[0], cost + next[1]});
                }
            }
        }

        int maxTime = Arrays.stream(minTime).max().getAsInt();
        return maxTime == Integer.MAX_VALUE ? -1 : maxTime;
    }
}

// Accepted - BFS
class SolutionBFS {
    public int networkDelayTime(int[][] times, int n, int k) {
        var graph = convertToGraph(times, n);
        var signalTime = bfs(graph, k, n);
        
        int result = Integer.MIN_VALUE;
        for(var i = 1; i <= n; i++)
            result = Math.max(result, signalTime[i]);

        if (result == Integer.MAX_VALUE) return -1;
        return result;
    }
    
    private List<int[]>[] convertToGraph(int[][] times, int n){
        List<int[]>[] graph = new ArrayList[n + 1]; // n + 1 because nodes are 1-indexed
        for(var i = 0; i <= n; i++)
            graph[i] = new ArrayList<>();

        for(var time : times)
            graph[time[0]].add(new int[]{time[1], time[2]});

        return graph;
    }
    
    private int[] bfs(List<int[]>[] graph, int start, int n) {
        var signalTime = new int[n + 1];
        Arrays.fill(signalTime, Integer.MAX_VALUE);
        signalTime[start] = 0;
        
        Queue<Integer> q = new LinkedList<>();
        q.offer(start);
        
        while (!q.isEmpty()) {
            var curr = q.poll();
            if(graph[curr].isEmpty()) continue;    // no neighbors for this node
            
            // BFS
            for(var edge : graph[curr]) {
                var currTime = signalTime[curr] + edge[1];
                
                if (signalTime[edge[0]] > currTime) {
                    signalTime[edge[0]] = currTime;
                    q.offer(edge[0]);
                }
            }
        }
        
        return signalTime;
    }
}