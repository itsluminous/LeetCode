// idea is to keep all matching x & y coordinates in same disjoint set
// for each disjoint set, 1 point will have to be left
class Solution {
    public int removeStones(int[][] stones) {
        var MAX = 10001;
        var uf = new UnionFind(MAX * 2);    // MAX for x + MAX for y

        for(var stone : stones)
            uf.union(stone[0], stone[1] + MAX); // offset Y coordinate by MAX so that x & y are distinct
        
        return stones.length - uf.distinctSetCount;
    }
}

public class UnionFind{
    int[] parent;
    int distinctSetCount;
    Set<Integer> uniquePoints;
    
    public UnionFind(int n){
        distinctSetCount = 0;
        uniquePoints = new HashSet<>();
        parent = new int[n];
        for(int i=0; i<n; i++)
            parent[i] = i;  // all are self parent initially
    }
    
    private int find(int point){
        if(parent[point] != point)
            parent[point] = find(parent[point]);
        return parent[point];
    }
    
    public void union(int p1, int p2){
        // check if we are seeing these points for first time
        checkUnique(p1);
        checkUnique(p2);

        var p1_p = find(p1);
        var p2_p = find(p2);
        if(p1_p == p2_p) return;

        parent[p1_p] = parent[p2_p];
        distinctSetCount--;
    }

    private void checkUnique(int point){
        if(!uniquePoints.contains(point)){
            uniquePoints.add(point);
            distinctSetCount++;
        }
    }
}