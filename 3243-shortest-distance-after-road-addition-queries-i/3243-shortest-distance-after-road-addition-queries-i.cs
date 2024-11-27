public class Solution {
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++)
            adjList[i] = new List<int>{i+1};

        var q = queries.Length;
        var ans = new int[q];
        
        for(var i=0; i<q; i++){
            adjList[queries[i][0]].Add(queries[i][1]);
            ans[i] = BFS(adjList);
        }

        return ans;
    }

    private int BFS(List<int>[] adjList){
        var queue = new Queue<int>();
        queue.Enqueue(0);

        var n = adjList.Length;
        var visited = new bool[n];
        visited[0] = true;

        for(var len=0; queue.Count > 0; len++){
            for(var i=queue.Count; i>0; i--){
                var curr = queue.Dequeue();
                if(curr == n-1) return len;
                foreach(var next in adjList[curr]){
                    if(visited[next]) continue;
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
        }

        return 0;
    }
}