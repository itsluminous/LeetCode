// a,b,c are nodes and a/b value is weight of that path
// a/c will be product of weight of all intermediate edges
// in soln below, perhaps a better way to represent graph will be List<Dictionary<string, double>
public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var graph = new List<List<Node>>();
        var dict = new Dictionary<string, int>();   // index of a node in the adjecency list
        
        // create adjacency list
        CreateGraph(graph, dict, equations, values);
        
        // find result
        var n = queries.Count;
        var result = new double[n];
        
        for(var i=0; i<n; i++)
            result[i] = FindWeight(graph, dict, new HashSet<string>(), queries[i][0], queries[i][1]);
        
        return result;
    }
    
    private double FindWeight(List<List<Node>> graph, Dictionary<string, int> dict, HashSet<string> visited, string start, string end){
        if(!dict.ContainsKey(start)) return -1.0;
        
        var connections = graph[dict[start]];
        foreach(var node in connections){
            if(node.text == end)
                return node.weight;
        }
        
        // DFS
        visited.Add(start);
        foreach(var node in connections){
            if(visited.Contains(node.text)) continue;
            var weight = FindWeight(graph, dict, visited, node.text, end);
            if(weight != -1)
                return weight * node.weight;
        }
        
        return -1.0;
    }
    
    private void CreateGraph(List<List<Node>> graph, Dictionary<string, int> dict, IList<IList<string>> equations, double[] values){
        for(var i=0; i<equations.Count; i++){
            string numer = equations[i][0], denom = equations[i][1];    // numerator, denominator
            if(!dict.ContainsKey(numer)){
                graph.Add(new List<Node>());
                dict[numer] = graph.Count - 1;
            }
            
            if(!dict.ContainsKey(denom)){
                graph.Add(new List<Node>());
                dict[denom] = graph.Count - 1;
            }
            
            var idx = dict[numer];
            graph[idx].Add(new Node(denom, values[i]));
            idx = dict[denom];
            graph[idx].Add(new Node(numer, 1/values[i]));
        }
    }
}

public class Node {
    public string text {get; set;}
    public double weight {get; set;}
    
    public Node(string text, double weight){
        this.text = text;
        this.weight = weight;
    }
}