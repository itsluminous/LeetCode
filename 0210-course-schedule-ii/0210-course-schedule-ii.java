class Solution {
    int[] dependencies;

    public int[] findOrder(int numCourses, int[][] prerequisites) {
        dependencies = new int[numCourses];
        var adjList = makeGraph(numCourses, prerequisites);

        // start with courses which have dependencies == 0, i.e. not dependent on anyone
        Queue<Integer> queue = new LinkedList<>();
        for(var i=0; i<numCourses; i++)
            if(dependencies[i] == 0)
                queue.offer(i);
        
        // BFS to start covering each available course one by one
        var order = new int[numCourses];
        var idx = 0;
        while(!queue.isEmpty()){
            var curr = queue.poll();
            order[idx] = curr;
            idx += 1;

            // each dependent of this course has one dependency satisfied
            // if all dependencies for a course is satisfied, then we add that in queue
            for(var next : adjList[curr]){
                dependencies[next]--;
                if(dependencies[next] == 0)
                    queue.offer(next);
            }
        }
        
        if(idx == numCourses) return order;
        return new int[0];
    }

    private List<Integer>[] makeGraph(int numCourses, int[][] prerequisites){
        List<Integer>[] adjList = new ArrayList[numCourses];
        for(var i=0; i<numCourses; i++) adjList[i] = new ArrayList<>();
        
        for(var edge : prerequisites){
            int after = edge[0], before = edge[1];
            adjList[before].add(after);
            dependencies[after]++;
        }
        
        return adjList;
    }
}