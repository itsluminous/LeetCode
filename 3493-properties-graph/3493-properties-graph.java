class Solution {
    public int numberOfComponents(int[][] properties, int k) {
        var n = properties.length;

        HashSet<Integer>[] propUniqNums = new HashSet[n];
        for(var i = 0; i < n; i++){
            propUniqNums[i] = new HashSet<Integer>();
            for(var num : properties[i]) propUniqNums[i].add(num);
        }
        
        var uf = new UnionFind(n);
        for(var i = 0; i < n; i++) {
            for(var j = i + 1; j < n; j++) {
                var intersectCount = computeIntersection(propUniqNums[i], propUniqNums[j]);
                if(intersectCount >= k)
                    uf.union(i, j);
            }
        }
        
        return uf.countComponents();
    }

    private int computeIntersection(HashSet<Integer> a, HashSet<Integer> b) {
        var count = 0;
        if (a.size() > b.size()) {
            var temp = a;
            a = b;
            b = temp;
        }
        
        for(var num : a)
            if(b.contains(num))
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

    public void union(int n1, int n2){
        var p1 = find(n1);
        var p2 = find(n2);
        if(p1 == p2) return;

        if(rank[p1] > rank[p2])
            parent[p2] = p1;
        else {
            parent[p1] = p2;
            if(rank[p1] == rank[p2])
                rank[p2]++;
        }
    }

    public int find(int node){
        if(parent[node] != node)
            parent[node] = find(parent[node]);
        return parent[node];
    }

    public int countComponents() {
        int count = 0;
        for(var i = 0; i < parent.length; i++)
            if(parent[i] == i)
                count++;
        return count;
    }
}