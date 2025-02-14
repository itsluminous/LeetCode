class Solution {
    public boolean isBipartite(int[][] graph) {
        var n = graph.length;
        var colors = new int[n];

        for(var i=0; i<n; i++)
            if(colors[i] == 0 && !isValid(graph, colors, i, 1))
                return false;
        return true;
    }

    private boolean isValid(int[][] graph, int[] colors, int node, int color){
        // if already colored, then check if it matches expectation
        if(colors[node] != 0)
            return colors[node] == color;
        
        colors[node] = color;
        
        // try to color all neighbours in opposite color
        for(var next : graph[node])
            if (!isValid(graph, colors, next, -color))
                return false;
        return true;
    }
}