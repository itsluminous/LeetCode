// a node will have either color 1 or -1. 0 means its not colored yet
public class Solution {
    public bool IsBipartite(int[][] graph) {
        var n = graph.Length;
        var colors = new int[n];
        
        //This graph might be a disconnected graph. So check each unvisited node.
        for(var i=0; i<n; i++){
            if(colors[i] == 0 && !IsValidColor(graph, colors, 1, i))
                return false;
        }
        return true;
    }
    
    private bool IsValidColor(int[][] graph, int[] colors, int color, int node){
        // if it is alrady colored, then just check if the color we are about to apply matches it
        if(colors[node] !=0) 
            return colors[node] == color;
        
        colors[node] = color;
        // all neighbours should have opposite color of this node
        foreach(var neighbour in graph[node]){
            if(!IsValidColor(graph, colors, -color, neighbour))
                return false;
        }
        
        return true;
    }
}