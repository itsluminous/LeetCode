public class Solution {
    List<int[]> path = new List<int[]>();

    public int[][] ValidArrangement(int[][] pairs) {
        // create graph, and count in & out degree
        // degree[i]++ if there is out degree, and degree[i]-- when there is in degree
        // this way we don't need to use two arrays to track in & out degree
        var degree = new Dictionary<int, int>();
        var adjList = new Dictionary<int, List<int>>();
        foreach(var pair in pairs){
            var (src, dest) = (pair[0], pair[1]);
            if(!adjList.ContainsKey(src)) adjList[src] = new List<int>();
            adjList[src].Add(dest);

            if(degree.ContainsKey(src)) degree[src]++;
            else degree[src] = 1;

            if(degree.ContainsKey(dest)) degree[dest]--;
            else degree[dest] = -1;
        }

        // find out a node which has degree = 1, because this would be starting point
        // this is an Eulerian trail i.e. one of the nodes which does not complete cycle in Eulerian path
        // if there is no such node, then it is a circular graph, and we can pick any start
        var start = pairs[0][0];
        foreach(var node in degree.Keys){
            if(degree[node] == 1){
                start = node;
                break;
            }
        }

        // traverse DFS from "start" to complete the path
        // Hierholzer's Algorithm
        DFS(adjList, start);
        
        // DFS will fill up path in reverse order
        path.Reverse();
        return path.ToArray();
    }

    private void DFS(Dictionary<int, List<int>> adjList, int start){
        if(!adjList.ContainsKey(start)) return;
        
        var connections = adjList[start];
        while(connections.Count != 0){
            var next = connections[0];
            connections.RemoveAt(0);
            DFS(adjList, next);
            
            // Ideally we insert at beginning so that we don't do reverse later, but that gives TLE
            // Other option is to use stack for connections, instead of a list
            path.Add(new []{start, next});
        }
    }
}