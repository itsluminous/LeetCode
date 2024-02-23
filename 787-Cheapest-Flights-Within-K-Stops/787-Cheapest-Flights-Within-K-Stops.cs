public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        if(src == dst) return 0;

        var adjMat = new int[n,n];
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++)
                adjMat[i,j] = -1;   // no connection
        
        foreach(var route in flights)
            adjMat[route[0], route[1]] = route[2];

        var minCostForStop = new int[n];
        Array.Fill(minCostForStop, Int32.MaxValue);
        
        // BFS
        var q = new Queue<StopCost>();
        var stops = 0;
        int minCost = Int32.MaxValue;
        q.Enqueue(new StopCost(src, 0));
        while(q.Count > 0 && stops <= k){
            var count = q.Count;
            for(var i=0; i<count; i++){
                var sc = q.Dequeue();
                var source = sc.stop;
                var costTillNow = sc.cost;
                for(var dest=0; dest<n; dest++){
                    // if there is a valid connection between two stops
                    if(adjMat[source,dest] != -1 && dest == dst)
                        minCost = Math.Min(minCost, costTillNow+adjMat[source,dest]);
                    else if(adjMat[source,dest] != -1){
                        var costToReach = costTillNow+adjMat[source,dest];
                        if(minCostForStop[dest] < costToReach) continue;    // we have reached this stop earlier with less cost 
                        minCostForStop[dest] = costToReach;
                        q.Enqueue(new StopCost(dest, costToReach));
                    }
                        
                }
            }
            stops++;
        }

        if(minCost == Int32.MaxValue) return -1;
        return minCost;
    }
}

class StopCost {
    public int stop;
    public int cost;

    public StopCost(int s, int c){
        stop = s;
        cost = c;
    }
}