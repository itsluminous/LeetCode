public class Solution {
    bool hasCycle = false;

    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        var sortedRows = TopologicalSort(rowConditions, k);
        var sortedCols = TopologicalSort(colConditions, k);

        // if there is a cyclic dependency
        if (sortedRows.Count == 0 || sortedCols.Count == 0)
            return new int[0][];

        var matrix = new int[k][];
        for (int i = 0; i < k; i++)
            matrix[i] = new int[k];

        for (int i = 0; i < k; i++)
            for (int j = 0; j < k; j++)
                if (sortedRows[i] == sortedCols[j])
                    matrix[i][j] = sortedRows[i];

        return matrix;  
    }

    private List<int> TopologicalSort(int[][] edges, int k)
    {
        // build adj list
        var graph = new List<int>[k + 1];
        for (int i = 0; i <= k; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges)
            graph[edge[0]].Add(edge[1]);

        // sort the vertices
        var sorted = new List<int>();
        var visited = new int[k + 1]; // 1 = visiting, 2 = visited
        hasCycle = false;

        // perform DFS for sorting
        for (var i = 1; i <= k; i++)
            if (visited[i] == 0)
            {
                DFS(graph, visited, sorted, i);
                if (hasCycle)
                    return new List<int>();
            }

        sorted.Reverse();
        return sorted;
    }

    private void DFS(List<int>[] graph, int[] visited, List<int> sorted, int node)
    {
        visited[node] = 1; // visiting
        foreach (var next in graph[node])
        {
            if (visited[next] == 0) {
                DFS(graph, visited, sorted, next);
                if (hasCycle)
                    return;
            }
            else if (visited[next] == 1) {
                hasCycle = true;
                return;
            }
        }

        visited[node] = 2; // visited
        sorted.Add(node);
    }
}