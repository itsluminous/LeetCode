public class Solution {
    int[] indegree;
    HashSet<int> nodes;
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // make graph from edges list
        nodes = new HashSet<int>();
        indegree = new int[numCourses];
        var adjList = MakeGraph(numCourses, prerequisites);
        
        // Add all nodes with 0 in-degree in queue
        var queue = new Queue<int>();
        for(var i=0; i<numCourses; i++){
            if(indegree[i] == 0)
                queue.Enqueue(i);
        }
        
        // keep removing leaves until nothing is left
        var result = new int[numCourses];
        var idx = 0;
        while(queue.Count > 0){
            var node = queue.Dequeue();
            result[idx++] = node;
            if(!nodes.Contains(node)) continue;
            var neighbours = adjList[node];
            foreach(var n in neighbours){
                indegree[n]--;
                // If in-degree of a neighbor becomes 0, add it to the Q
                if(indegree[n] == 0) queue.Enqueue(n);
            }   
        }
        
        // check if topological sort is possible or not
        if(idx == numCourses) return result;
        return new int[0];
    }
    
    private List<int>[] MakeGraph(int n, int[][] edges){
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++) adjList[i] = new List<int>();
        
        foreach(var edge in edges){
            adjList[edge[1]].Add(edge[0]);  // finish course edge[1] before edge[0]
            indegree[edge[0]]++;
            nodes.Add(edge[1]);
        }
        
        return adjList;
    }
}