// using centroid logic. See https://leetcode.com/problems/minimum-height-trees/discuss/76055/Share-some-thoughts
public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        // base case
        if(n == 1) return new List<int>{0};
        
        // make graph from edges list
        var adjList = MakeGraph(n, edges);
        
        // get all leaf nodes (i.e. nodes who have only one connection)
        var leaves = GetLeaves(adjList);
        
        // trim the leaves until reaching last two centroids
        var remainingNodes = n;
        while(remainingNodes > 2){
            remainingNodes -= leaves.Count;
            // remove current leaves along with edges, and find out new leaf nodes
            var newLeaves = new List<int>();
            foreach(var leaf in leaves){
                var parent = adjList[leaf].First();
                // remove the edge along with leaf node
                adjList[parent].Remove(adjList[parent].Single(x => x == leaf));
                // if the parent node has only one connection after removal, then it is leaf node
                if(adjList[parent].Count == 1) newLeaves.Add(parent);
            }
            
            // prepare for next iteration
            leaves = newLeaves;
        }
        
        return leaves;
    }
    
    private List<int>[] MakeGraph(int n, int[][] edges){
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++) adjList[i] = new List<int>();
        
        foreach(var edge in edges){
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        return adjList;
    }
    
    private List<int> GetLeaves(List<int>[] adjList){
        var leaves = new List<int>();
        
        for(var i=0; i<adjList.Length; i++){
            if(adjList[i].Count == 1)
                leaves.Add(i);
        }
        
        return leaves;
    }
}

// TLE - using DFS
public class Solution1 {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var adjList = MakeGraph(n, edges);
        
        var minHeight = int.MaxValue;
        var mht = new List<int>();
        for(var i=0; i<n; i++){
            var height = DFS(adjList, i, new bool[n]);
            // Console.WriteLine($"Head={i}, height={height}, minHeight={minHeight}");
            // if height is more than current min height, we are not interested
            if(height > minHeight) continue;
            // if we found same height tree as current min, then add it to mht list
            if(height == minHeight){
                mht.Add(i);
                continue;
            }
            // if we found smaller height, then start new list mht
            mht = new List<int>{i};
            minHeight = height;
        }
        
        return mht;
    }
    
    private int DFS(List<int>[] adjList, int idx, bool[] visited){
        if(visited[idx]) return 0;
        visited[idx] = true;
        var connections = adjList[idx];
        var height = 1;
        foreach(var node in connections){
            var currHeight = 1 + DFS(adjList, node, visited);
            height = Math.Max(height, currHeight);
        }
        return height;
    }
    
    private List<int>[] MakeGraph(int n, int[][] edges){
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++) adjList[i] = new List<int>();
        
        foreach(var edge in edges){
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        return adjList;
    }
}