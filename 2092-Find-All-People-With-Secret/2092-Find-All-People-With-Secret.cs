public class Solution {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        var m = meetings.Length;
        var uf = new UnionFind(n);

        Sort<int>(meetings, 2);     // sort meetings by their time of occurence
        uf.Union(firstPerson, 0);   // person 0 shares secret with person firstPerson
        
        for(var i=0; i<m;){
            var people = new List<int>();
            var time = meetings[i][2];
            while(i<m && meetings[i][2] == time){
                uf.Union(meetings[i][0], meetings[i][1]);
                people.Add(meetings[i][0]);
                people.Add(meetings[i][1]);
                i++;
            }
            
            // if person p does not have secret, remove them from any group
            foreach(var p in people){
                if(uf.Find(p) != 0) uf.Reset(p);
            }
        }
        
        var result = new List<int>();
        for(var i=0; i<n; i++)
            if(uf.Find(i) == 0)     // if person i shares group with 0, they have secret
                    result.Add(i);
        
        return result;
    }
    
    private static void Sort<T>(T[][] data, int col) 
    { 
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x,y) => comparer.Compare(x[col],y[col])); 
    } 
}

public class UnionFind{
    int[] id;
    
    public UnionFind(int n){
        id = new int[n];
        for(int i=0; i<n; i++)
            id[i] = i;                  // all are self parent initially
    }
    
    public int Find(int p){
        if(id[p] != p) id[p] = Find(id[p]);
        return id[p];
    }
    
    public void Union(int p1, int p2){
        var p1_p = Find(p1);            // find parent node of person p1
        var p2_p = Find(p2);            // find parent node of person p2
        if(p1_p == 0) id[p2_p] = id[p1_p]; 
        else id[p1_p] = id[p2_p];
    }
    
    public void Reset(int p){           // Reset function to remove that person from any group
        id[p] = p; 
    }
}



// Accepted - Using Priority Queue
public class SolutionPQ {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();
        for(int i = 0; i < n; i++)
            graph[i] = new List<(int, int)>();

        foreach(int[] meet in meetings) {
            graph[meet[0]].Add((meet[1], meet[2]));
            graph[meet[1]].Add((meet[0], meet[2]));
        }

        List<int> ans = new List<int>();
        PriorityQueue<(int, int), int> que = new PriorityQueue<(int, int), int>();
        bool[] visited = new bool[n];
        que.Enqueue((0, firstPerson), 0);
        que.Enqueue((0, 0), 0);
        while(que.Count > 0) {
            var cur = que.Dequeue();
            if(visited[cur.Item2])
                continue;
            visited[cur.Item2] = true;
            ans.Add(cur.Item2);
            int time = cur.Item1;
            foreach(var neigh in graph[cur.Item2]) {
                if(!visited[neigh.Item1] && time <= neigh.Item2)
                    que.Enqueue((neigh.Item2, neigh.Item1), neigh.Item2);
            }
        }
        return ans;
    }
}