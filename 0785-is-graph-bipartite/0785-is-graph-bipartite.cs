public class Solution {
    public bool IsBipartite(int[][] graph) {
        var n = graph.Length;
        var colors = new int[n];

        bool IsValid(int node, int color){
            // if already colored, then check if it matches expectation
            if(colors[node] != 0)
                return colors[node] == color;
            
            colors[node] = color;
            
            // try to color all neighbours in opposite color
            foreach(var next in graph[node])
                if (!IsValid(next, -color))
                    return false;
            return true;
        }

        for(var i=0; i<n; i++)
            if(colors[i] == 0 && !IsValid(i, 1))
                return false;
        return true;
    }
}