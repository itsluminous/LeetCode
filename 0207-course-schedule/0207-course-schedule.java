class Solution {
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        // build adj list for dependency
        List<Integer>[] adjList = new ArrayList[numCourses];
        for(var prereq : prerequisites){
            if(adjList[prereq[0]] == null) adjList[prereq[0]] = new ArrayList<>();
            adjList[prereq[0]].add(prereq[1]);
        }

        // for each course, check if it can be completed
        for(var i=0; i<numCourses; i++){
            if(!dfs(adjList, i, new boolean[numCourses]))
                return false;
        }
        return true;
    }

    private boolean dfs(List<Integer>[] adjList, int idx, boolean[] visited){
        if(adjList[idx] == null) return true;   // this course is completed

        if(visited[idx]) return false;  // cyclic dependency
        visited[idx] = true;
        
        for(var depdt : adjList[idx]){
            if(!dfs(adjList, depdt, visited)) return false;
        }

        // mark this course as completed
        adjList[idx] = null;
        return true;
    }
}