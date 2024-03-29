// With just one array
public class Solution {
    public int FindJudge(int n, int[][] trust) {
        // array to track who is trusted by how many
        var trustCount = new int[n+1];
        
        // fill up trust count
        foreach(var t in trust){
            trustCount[t[0]]--;
            trustCount[t[1]]++;
        }
        
        // check for any node which is trusted by everyone except them
        for(var i=1; i<=n; i++)
            if(trustCount[i] == n-1)
                return i;
        
        // if we did not find any such node, then there is no conclusion
        return -1;
    }
}

// Accepted - with graph
public class Solution1 {
    public int FindJudge(int n, int[][] trust) {
        // array to track who does not trust anyone
        var hasTrust = new bool[n+1];
        
        // initialize graph
        var adjList = new List<int>[n+1];
        for(var i=0; i<=n; i++)
            adjList[i] = new List<int>();
        
        // make graph
        foreach(var t in trust){
            hasTrust[t[0]] = true;
            adjList[t[1]].Add(t[0]);
        }   
        
        // check for any node which is trusted by everyone except them
        for(var i=1; i<=n; i++)
            if(adjList[i].Count == n-1 && !hasTrust[i])
                return i;
        
        // if we did not find any such node, then there is no conclusion
        return -1;
    }
}
