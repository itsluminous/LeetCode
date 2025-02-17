// Accepted - Dijkastra
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        // make graph
        var adj = new List<int[]>[n+1];
        for(var i = 0; i <= n; i++)
            adj[i] = new List<int[]>();

        foreach(var edge in times)
            adj[edge[0]].Add([edge[1], edge[2]]);
        
        // initialize cost
        var minTime = new int[n+1];
        Array.Fill(minTime, int.MaxValue);
        minTime[k] = 0;
        minTime[0] = 0; // array is 1 indexed, so this should not be counted later

        // initialize pq for Dijkstra
        var queue = new PriorityQueue<int[], int>();
        queue.Enqueue([k, 0], 0); // node, time

        while(queue.Count > 0) {
            var nodeTime = queue.Dequeue();
            int node = nodeTime[0], cost = nodeTime[1];
            if(minTime[node] < cost) continue;  // found better path already

            foreach(var next in adj[node]){
                if(minTime[next[0]] > cost + next[1]){
                    minTime[next[0]] = cost + next[1];
                    queue.Enqueue([next[0], cost + next[1]], cost + next[1]);
                }
            }
        }

        var maxTime = minTime.Max();
        return maxTime == int.MaxValue ? -1 : maxTime;
    }
}

// Accepted - BFS
public class SolutionBFS {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var graph = ConvertToGraph(times, n);
        var signalTime = BFS(graph, k, n);
        
        var result = int.MinValue;
        for(var i=1; i<=n; i++)
            result = Math.Max(result, signalTime[i]);
        
        if(result == int.MaxValue) return -1;
        return result;
    }
    
    private List<(int,int)>[] ConvertToGraph(int[][] times, int n){
        var graph = new List<(int dest, int weight)>[n+1]; // n+1 because nodes are 1-indexed
        for(var i=0; i<=n; i++)
            graph[i] = new List<(int,int)>();
        
        foreach(var time in times)
            graph[time[0]].Add((time[1], time[2]));
        
        return graph;
    }
    
    private int[] BFS(List<(int dest, int weight)>[] graph, int start, int n){
        var signalTime = new int[n+1];
        for(var i=1; i<=n; i++)
            signalTime[i] = int.MaxValue;
        signalTime[start] = 0;
        
        var q = new Queue<int>();
        q.Enqueue(start);
        
        while(q.Count > 0){
            var curr = q.Dequeue();
            if(graph[curr].Count == 0) continue;    // no neighbours for this node
            
            // BFS
            foreach(var edge in graph[curr]){
                var currTime = signalTime[curr] + edge.weight;
                
                if (signalTime[edge.dest] > currTime) {
                    signalTime[edge.dest] = currTime;
                    q.Enqueue(edge.dest);
                }
            }
        }
        
        return signalTime;
    }
}