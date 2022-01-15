public class Solution {
    public int MinJumps(int[] arr) {
        int n = arr.Length, steps = 0;
        var visited = new bool[n];
        visited[0] = true;
        
        // fill out dictionary to track indexes for same numbers
        var match = new Dictionary <int, List<int>>();
        for(var i=0; i<n; i++){
            var val = arr[i];
            if(!match.ContainsKey(val)) match[val] = new List<int>();
            match[val].Add(i);
        }
        
        // start BFS
        var queue = new Queue<int>();
        queue.Enqueue(0);   // by default first index will be traversed
        
        while(queue.Count > 0){
            var size = queue.Count;
            for(var i=0; i<size; i++){
                var idx = queue.Dequeue();
                if(idx == n-1) return steps;    // reached last node
                var next = match[arr[idx]];     // all indexes matching value
                next.Add(idx-1);                // curr - 1 index
                next.Add(idx+1);                // curr + 1 index
                
                foreach(var j in next){
                    if(j < 0 || j == n || visited[j]) continue;
                    visited[j] = true;
                    queue.Enqueue(j);
                }
                next.Clear();   // delete matching indexes once processed
            }
            steps++;
        }
        
        return steps;
    }
}