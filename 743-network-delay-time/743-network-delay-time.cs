public class Solution {
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