public class Solution {
    public IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries) {
        var connected = new bool[n,n];
        foreach(var edge in prerequisites)
            connected[edge[0],edge[1]] = true;
        
        for(var middle = 0; middle < n; middle++)
            for(var src = 0; src < n; src++)
                for(var dest = 0; dest < n; dest++)
                    connected[src,dest] = connected[src,dest] || (connected[src,middle] && connected[middle,dest]);

        var ans = new List<bool>();
        foreach(var query in queries)
            ans.Add(connected[query[0],query[1]]);
        
        return ans;
    }
}