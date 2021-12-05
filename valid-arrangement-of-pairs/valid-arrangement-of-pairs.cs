// Basically we want to find an Eulerian path - a path which covers all edges only once. Nodes can be repeated though
// To do this we need to know a starting point. If there is any path which does not end at starting point, we pick that
// Else we pick any random path which starts at any random point
// After this we perform DFS using Hierholzer's Algorithm

public class Solution {
    Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
    List<int[]> path = new List<int[]>();
    
    public int[][] ValidArrangement(int[][] pairs) {
        var inDegree = new Dictionary<int,int>();
        
        // generate adjacency list and populate indegree of all nodes
        foreach(var pair in pairs){
            if(!adjList.ContainsKey(pair[0])) adjList[pair[0]] = new List<int>();
            adjList[pair[0]].Add(pair[1]);
            
            if(!inDegree.ContainsKey(pair[0])) inDegree[pair[0]] = 0;
            inDegree[pair[0]]++;
            
            if(!inDegree.ContainsKey(pair[1])) inDegree[pair[1]] = 0;
            inDegree[pair[1]]--;
        }
        
        // now find a node which has indegree 1. 
        // This is an Eulerian trail i.e. one of the nodes which does not complete cycle in Eulerian path
        // if no such node exists, we can pick any random node
        var start = pairs[0][0];
        foreach(var node in inDegree.Keys){
            if(inDegree[node] == 1){
                start = node;
                break;
            }
        }
        
        DFS(start);
        
        path.Reverse();
        return path.ToArray();
    }
    
    // Hierholzer's Algorithm
    private void DFS(int start){
        var connections = adjList.ContainsKey(start) ? adjList[start] : null;
        while(connections != null && connections.Count != 0){
            var next = connections[0];
            connections.RemoveAt(0);
            DFS(next);
            // We should ideally insert at beginning so that we don't do reverse later, but getting TLE if we do that
            path.Add(new []{start, next});
        }
    }
}