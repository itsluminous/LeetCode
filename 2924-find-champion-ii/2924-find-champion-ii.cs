public class Solution {
    public int FindChampion(int n, int[][] edges) {
        if(n == 1) return 0;   // no competitors

        // 0 = undefined, 1 = weak, 2 = strong
        var val = new int[n];

        foreach(var edge in edges){
            var (src, dest) = (edge[0], edge[1]);
            val[dest] = 1;
            if(val[src] == 0) val[src] = 2;
        }

        var ans = -1;
        for(var i=0; i<n; i++){
            if(val[i] == 1) continue;   // don't care about losers
            if(val[i] == 0) return -1;  // if we don't know about even a single team, return -1
            if(ans != -1) return -1;    // we already have one strong team
            ans = i;
        }

        return ans;
    }
}