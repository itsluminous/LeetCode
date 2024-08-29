// idea is to keep all matching x & y coordinates in same disjoint set
// for each disjoint set, 1 point will have to be left
public class Solution {
    public int RemoveStones(int[][] stones) {
        var MAX = 10001;
        var uf = new UnionFind(MAX * 2);    // MAX for x + MAX for y

        foreach(var stone in stones)
            uf.Union(stone[0], stone[1] + MAX); // offset Y coordinate by MAX so that x & y are distinct
        
        return stones.Length - uf.distinctSetCount;
    }
}

public class UnionFind{
    int[] parent;
    public int distinctSetCount;
    HashSet<int> uniquePoints;
    
    public UnionFind(int n){
        distinctSetCount = 0;
        uniquePoints = new();
        parent = new int[n];
        for(var i=0; i<n; i++)
            parent[i] = i;  // all are self parent initially
    }
    
    private int Find(int point){
        if(parent[point] != point)
            parent[point] = Find(parent[point]);
        return parent[point];
    }
    
    public void Union(int p1, int p2){
        // check if we are seeing these points for first time
        CheckUnique(p1);
        CheckUnique(p2);

        var p1_p = Find(p1);
        var p2_p = Find(p2);
        if(p1_p == p2_p) return;

        parent[p1_p] = parent[p2_p];
        distinctSetCount--;
    }

    private void CheckUnique(int point){
        if(!uniquePoints.Contains(point)){
            uniquePoints.Add(point);
            distinctSetCount++;
        }
    }
}