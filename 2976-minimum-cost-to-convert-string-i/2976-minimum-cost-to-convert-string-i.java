class Solution {
    int INF = Integer.MAX_VALUE;

    public long minimumCost(String source, String target, char[] original, char[] changed, int[] cost) {
        var n = 26;
        var minCost = new long[n][n];
        for(var i=0; i<n; i++){
            Arrays.fill(minCost[i], INF);
            minCost[i][i] = 0;
        }

        for(var i=0; i<original.length; i++){
            int src = (original[i] - 'a'), dest = (changed[i] - 'a');
            minCost[src][dest] = Math.min(minCost[src][dest], cost[i]);
        }

        floyd(n, minCost);
        return getMinCost(source, target, minCost);
    }

    private long getMinCost(String source, String target, long[][] minCost){
        long cost = 0;
        for(var i=0; i<source.length(); i++){
            int src = (source.charAt(i) - 'a'), dest = (target.charAt(i) - 'a');
            if(minCost[src][dest] == INF) return -1;
            cost += minCost[src][dest];
        }
        return cost;
    }

    private void floyd(int n, long[][] minCost){
        for(var k=0; k<n; k++){
            for(var i=0; i<n; i++){
                for(var j=0; j<n; j++){
                        minCost[i][j] = Math.min(minCost[i][j], 
                                                 minCost[i][k] + minCost[k][j]);
                }
            }
        }
    }
}