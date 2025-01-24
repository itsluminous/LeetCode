public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var n = graph.Length;
        var visited = new bool[n];
        var safeMap = new Dictionary<int, bool>();

        bool IsSafe(int node) {
            // terminal node is always safe
            if (graph[node].Length == 0) {
                safeMap[node] = true;
                return true;
            }

            // already evaluated node
            if (safeMap.ContainsKey(node)) return safeMap[node];

            // revisiting a node is unsafe
            if (visited[node]) {
                safeMap[node] = false;
                return false;
            }
            visited[node] = true;

            // check if all paths are safe
            var currSafe = true;
            foreach(var dest in graph[node]) {
                currSafe &= IsSafe(dest);
                if(!currSafe) break;
            }

            safeMap[node] = currSafe;
            visited[node] = false;
            return currSafe;
        }

        var safeNodes = new List<int>();
        for(var i = 0; i < n; i++)
            if(IsSafe(i)) safeNodes.Add(i);

        return safeNodes;
    }
}
