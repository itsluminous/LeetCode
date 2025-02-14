public class Solution {
    int[] dependencies;

    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        dependencies = new int[numCourses];
        var adjList = MakeGraph(numCourses, prerequisites);

        // start with courses which have dependencies == 0, i.e. not dependent on anyone
        var queue = new Queue<int>();
        for(var i=0; i<numCourses; i++)
            if(dependencies[i] == 0)
                queue.Enqueue(i);
        
        // BFS to start covering each available course one by one
        var order = new int[numCourses];
        var idx = 0;
        while(queue.Count > 0){
            var curr = queue.Dequeue();
            order[idx] = curr;
            idx += 1;

            // each dependent of this course has one dependency satisfied
            // if all dependencies for a course is satisfied, then we add that in queue
            foreach(var next in adjList[curr]){
                dependencies[next]--;
                if(dependencies[next] == 0)
                    queue.Enqueue(next);
            }
        }
        
        if(idx == numCourses) return order;
        return new int[0];
    }

    private List<int>[] MakeGraph(int numCourses, int[][] prerequisites){
        var adjList = new List<int>[numCourses];
        for(var i=0; i<numCourses; i++) adjList[i] = new List<int>();
        
        foreach(var edge in prerequisites){
            int after = edge[0], before = edge[1];
            adjList[before].Add(after);
            dependencies[after]++;
        }
        
        return adjList;
    }
}