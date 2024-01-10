// Using DFS - Reads each node only once
public class Solution {
    int maxDistance = 0;

    public int AmountOfTime(TreeNode root, int start) {
        Traverse(root, start);
        return maxDistance;
    }

    public int Traverse(TreeNode root, int start) {
        if(root == null) return 0;
        
        var depth = 0;
        var leftDepth = Traverse(root.left, start);
        var rightDepth = Traverse(root.right, start);

        if(root.val == start) {
            maxDistance = Math.Max(leftDepth, rightDepth);
            depth = -1;
        }
        else if (leftDepth >= 0 && rightDepth >= 0) {
            depth = Math.Max(leftDepth, rightDepth) + 1;
        }
        else {
            var distance = Math.Abs(leftDepth) + Math.Abs(rightDepth);
            maxDistance = Math.Max(maxDistance, distance);
            depth = Math.Min(leftDepth, rightDepth) -1;
        }

        return depth;
    }
}

// This also passess, but we read each node twice - when creating graph & during BFS
public class SolutionDFS {
    LinkedList<int>[] graph;
    int count;
    const int MAX = 100001; // 10^5

    public int AmountOfTime(TreeNode root, int start) {
        graph = new LinkedList<int>[MAX]; // 10^5
        for(var i=0; i<MAX; i++) graph[i] = new LinkedList<int>();
        count = 0;
        ConvertTreeToGraph(root, null);
        var steps = PerformDFS(start);
        return steps;
    }

    private void ConvertTreeToGraph(TreeNode node, TreeNode parent){
        if(node == null) return;
        count++;
        if(parent != null){
            graph[node.val].AddLast(parent.val);
            graph[parent.val].AddLast(node.val);
        }
        ConvertTreeToGraph(node.left, node);
        ConvertTreeToGraph(node.right, node);
    }

    private int PerformDFS(int start){
        var visited = new bool[MAX];
        var steps = -1;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        do{
            var len = queue.Count;
            for(var i=0; i<len; i++){
                var val = queue.Dequeue();
                visited[val] = true;
                foreach(var neighbour in graph[val]){
                    if(!visited[neighbour])
                        queue.Enqueue(neighbour);
                }
            }
            steps++;
        } while(queue.Count > 0);

        return steps;
    }
}