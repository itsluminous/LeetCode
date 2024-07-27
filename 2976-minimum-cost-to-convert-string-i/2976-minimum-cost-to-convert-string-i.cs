public class Solution {
    const int INF = int.MaxValue;

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        var n = 26;
        var minCost = new long[n][];
        for(var i=0; i<n; i++){
            minCost[i] = new long[n];
            for(var j=0; j<n; j++)
                minCost[i][j] = INF;
            minCost[i][i] = 0;
        }

        for(var i=0; i<original.Length; i++){
            int src = (original[i] - 'a'), dest = (changed[i] - 'a');
            minCost[src][dest] = Math.Min(minCost[src][dest], cost[i]);
        }

        Floyd(n, minCost);
        return MinCost(source, target, minCost);
    }

    private long MinCost(string source, string target, long[][] minCost){
        long cost = 0;
        for(var i=0; i<source.Length; i++){
            int src = (source[i] - 'a'), dest = (target[i] - 'a');
            if(minCost[src][dest] == INF) return -1;
            cost += minCost[src][dest];
        }
        return cost;
    }

    private void Floyd(int n, long[][] minCost){
        for(var k=0; k<n; k++){
            for(var i=0; i<n; i++){
                for(var j=0; j<n; j++){
                        minCost[i][j] = Math.Min(minCost[i][j], 
                                                 minCost[i][k] + minCost[k][j]);
                }
            }
        }
    }
}