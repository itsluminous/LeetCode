class Solution {
    public List<Boolean> checkIfPrerequisite(int n, int[][] prerequisites, int[][] queries) {
        var connected = new boolean[n][n];
        for(var edge : prerequisites)
            connected[edge[0]][edge[1]] = true;
        
        for(var middle = 0; middle < n; middle++)
            for(var src = 0; src < n; src++)
                for(var dest = 0; dest < n; dest++)
                    connected[src][dest] = connected[src][dest] || (connected[src][middle] && connected[middle][dest]);

        var ans = new ArrayList<Boolean>();
        for(var query : queries)
            ans.add(connected[query[0]][query[1]]);
        
        return ans;
    }
}