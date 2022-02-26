public class Solution {
    public int ShortestPathLength(int[][] graph) {
        if(graph.Length <= 1) return 0;
        
        int n = graph.Length, min = int.MaxValue;
        var allVisitedMask = (1 << n) - 1;
        var visited = new bool[n, allVisitedMask];  // if allVisitedMask = 1111, then value of allVisitedMask = 15 i.e. 15 possible masks out of it
        var q = new Queue<int[]>();
        
        // initialize starting state with each node
        for(var i=0; i<n; i++){
            q.Enqueue(new []{i, 1<<i}); // i-th node will be visited by default
            visited[i, 1<<i] = true;
        }
        
        // now traverse DFS until we find all nodes are visited
        var steps = 1;
        while(q.Count > 0){
            var len = q.Count;
            for(var i=0; i<len; i++){
                var curr = q.Dequeue();
                int node = curr[0], mask = curr[1];
                foreach(var neighbour in graph[node]){
                    var nextMask = mask | (1 << neighbour); // mark current neighbour as visited
                    if(nextMask == allVisitedMask)          // if all nodes are visited, we got ans
                        return steps;
                    if(!visited[neighbour, nextMask]){      // if we never found this situation earlier
                        visited[neighbour, nextMask] = true;
                        q.Enqueue(new []{neighbour, nextMask});
                    }
                }
            }
            steps++;
        }
        
        return -1;
    }
}