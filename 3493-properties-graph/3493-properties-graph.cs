public class Solution {
    public int NumberOfComponents(int[][] properties, int k) {
        var n = properties.Length;

        var propUniqNums = new HashSet<int>[n];
        for(var i = 0; i < n; i++)
            propUniqNums[i] = new HashSet<int>(properties[i]);
        
        var uf = new UnionFind(n);
        for(var i = 0; i < n; i++) {
            for(var j = i + 1; j < n; j++) {
                var intersectCount = ComputeIntersection(propUniqNums[i], propUniqNums[j]);
                if(intersectCount >= k)
                    uf.Union(i, j);
            }
        }
        
        return uf.CountComponents();
    }

    private int ComputeIntersection(HashSet<int> a, HashSet<int> b) {
        var count = 0;
        if (a.Count > b.Count) {
            var temp = a;
            a = b;
            b = temp;
        }
        
        foreach(var num in a)
            if(b.Contains(num))
                count++;

        return count;
    }
}

class UnionFind{
    int[] parent, rank;

    public UnionFind(int n){
        rank = new int[n];
        parent = new int[n];
        for(var i=0; i<n; i++)
            parent[i] = i;
    }

    public void Union(int n1, int n2){
        var p1 = Find(n1);
        var p2 = Find(n2);
        if(p1 == p2) return;

        if(rank[p1] > rank[p2])
            parent[p2] = p1;
        else {
            parent[p1] = p2;
            if(rank[p1] == rank[p2])
                rank[p2]++;
        }
    }

    public int Find(int node){
        if(parent[node] != node)
            parent[node] = Find(parent[node]);
        return parent[node];
    }

    public int CountComponents() {
        int count = 0;
        for(var i = 0; i < parent.Length; i++)
            if(parent[i] == i)
                count++;
        return count;
    }
}