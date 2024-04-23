public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var graph = ConvertToGraph(n, edges);       // convert graph to adjacency list
        var leaves = GetLeaves(graph);              // get all leaf nodes of graph

        // now, starting from leaf nodes, keep going in, till we reach center (root node)
        while(n > 2){
            n -= leaves.Count;
            var newLeaves = new List<int>();
            foreach(var leaf in leaves){
                var parent = graph[leaf].First();
                graph[parent].Remove(leaf);          // remove link between the leaf node and it's parent
                if(graph[parent].Count == 1) newLeaves.Add(parent);
            }
            leaves = newLeaves;
        }
        return leaves;
    }

    private HashSet<int>[] ConvertToGraph(int n, int[][] edges){
        var graph = new HashSet<int>[n];
        for(var i=0; i<n; i++) graph[i] = new HashSet<int>();

        foreach(var edge in edges){
            var (n1, n2) = (edge[0], edge[1]);
            graph[n1].Add(n2);
            graph[n2].Add(n1);
        }

        return graph;
    }

    private List<int> GetLeaves(HashSet<int>[] graph){
        var leaves = new List<int>();
        for(var i=0; i<graph.Length; i++)
            // <= instead of == because 0 link means there is only 1 node in tree
            if(graph[i].Count <= 1) leaves.Add(i);      
        
        return leaves;
    }
}