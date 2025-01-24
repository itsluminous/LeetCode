class Solution {
    private boolean[] visited;
    private Map<Integer, Boolean> safeMap;

    public List<Integer> eventualSafeNodes(int[][] graph) {
        var n = graph.length;
        visited = new boolean[n];
        safeMap = new HashMap<>();

        List<Integer> safeNodes = new ArrayList<>();
        for(var i = 0; i < n; i++)
            if(isSafe(graph, i)) safeNodes.add(i);

        return safeNodes;
    }

    private boolean isSafe(int[][] graph, int node) {
        // terminal node is always safe
        if (graph[node].length == 0) {
            safeMap.put(node, true);
            return true;
        }

        // already evaluated node
        if(safeMap.containsKey(node)) return safeMap.get(node);

        // revisiting a node is unsafe
        if(visited[node]) {
            safeMap.put(node, false);
            return false;
        }
        visited[node] = true;

        // check if all paths are safe
        var currSafe = true;
        for(var dest : graph[node]) {
            currSafe &= isSafe(graph, dest);
            if (!currSafe) break;
        }

        safeMap.put(node, currSafe);
        visited[node] = false;
        return currSafe;
    }
}
