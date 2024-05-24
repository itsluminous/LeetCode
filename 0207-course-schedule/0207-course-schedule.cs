class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // build adj list for dependency
        var adjList = new List<int>[numCourses];
        foreach(var prereq in prerequisites){
            if(adjList[prereq[0]] == null) adjList[prereq[0]] = new List<int>();
            adjList[prereq[0]].Add(prereq[1]);
        }

        // for each course, check if it can be completed
        for(var i=0; i<numCourses; i++){
            if(!DFS(adjList, i, new bool[numCourses]))
                return false;
        }
        return true;
    }

    private bool DFS(List<int>[] adjList, int idx, bool[] visited){
        if(adjList[idx] == null) return true;   // this course is completed

        if(visited[idx]) return false;  // cyclic dependency
        visited[idx] = true;
        
        foreach(var depdt in adjList[idx]){
            if(!DFS(adjList, depdt, visited)) return false;
        }

        // mark this course as completed
        adjList[idx] = null;
        return true;
    }
}