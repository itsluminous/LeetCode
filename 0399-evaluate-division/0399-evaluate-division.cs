public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        // make adjacency list. 
        // Weight of edge connecting nodeA & nodeB is the value of nodeA / nodeB
        var graph = MakeGraph(equations, values);

        var n = queries.Count;
        var ans = new double[n];
        for(var i=0; i<n; i++)
            ans[i] = GetValue(graph, new HashSet<string>(), queries[i][0], queries[i][1]);
        
        return ans;
    }

    private double GetValue(Dictionary<string, IList<Edge>> graph, HashSet<string> visited, string src, string dest){
        if(!graph.ContainsKey(src) || !graph.ContainsKey(dest)) return -1.0;

        // if the two nodes in question are directly connected, return value directly
        foreach(var edge in graph[src])
            if(edge.dest == dest) return edge.weight;
        
        // in case of no direct connection, perform DFS
        // for every edge travelled, the weight will keep multiplying
        visited.Add(src);
        foreach(var edge in graph[src]){
            if(visited.Contains(edge.dest)) continue;
            var weight = GetValue(graph, visited, edge.dest, dest);
            if(weight != -1) return (edge.weight * weight);
        }

        // could not find a connection
        return -1.0;
    }

    private Dictionary<string, IList<Edge>> MakeGraph(IList<IList<string>> equations, double[] values){
        var graph = new Dictionary<string, IList<Edge>>();
        for(var i=0; i<equations.Count; i++){
            var (src, dest, weight) = (equations[i][0], equations[i][1], values[i]);
            if(!graph.ContainsKey(src)) graph[src] = new List<Edge>();
            if(!graph.ContainsKey(dest)) graph[dest] = new List<Edge>();

            graph[src].Add(new Edge(dest, weight));
            graph[dest].Add(new Edge(src, 1/weight));
        }
        return graph;
    }
}

public class Edge{
   public string dest;
   public double weight; 

   public Edge(string d, double w){
        dest = d;
        weight = w;
   }
}