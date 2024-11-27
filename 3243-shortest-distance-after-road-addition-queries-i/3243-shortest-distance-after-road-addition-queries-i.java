class Solution {
    public int[] shortestDistanceAfterQueries(int n, int[][] queries) {
        List<Integer>[] adjList = new ArrayList[n];
        for(var i=0; i<n; i++)
            adjList[i] = new ArrayList<>(Arrays.asList(i + 1));

        var q = queries.length;
        var ans = new int[q];
        
        for(var i=0; i<q; i++){
            adjList[queries[i][0]].add(queries[i][1]);
            ans[i] = bfs(adjList);
        }

        return ans;
    }

    private int bfs(List<Integer>[] adjList){
        Queue<Integer> queue = new LinkedList<>();
        queue.offer(0);

        var n = adjList.length;
        var visited = new boolean[n];
        visited[0] = true;

        for(var len=0; !queue.isEmpty(); len++){
            for(var i=queue.size(); i>0; i--){
                var curr = queue.poll();
                if(curr == n-1) return len;
                for(var next : adjList[curr]){
                    if(visited[next]) continue;
                    visited[next] = true;
                    queue.offer(next);
                }
            }
        }

        return 0;
    }
}