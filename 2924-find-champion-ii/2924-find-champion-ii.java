class Solution {
    public int findChampion(int n, int[][] edges) {
        if(n == 1) return 0;   // no competitors

        // 0 = undefined, 1 = weak, 2 = strong
        var val = new int[n];

        for(var edge : edges){
            val[edge[1]] = 1;
            if(val[edge[0]] == 0) val[edge[0]] = 2;
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