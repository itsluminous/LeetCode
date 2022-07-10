public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int costSkip = cost[1], costTake = cost[0], idx = 2;
        for(int i=2; i<cost.Length; i++){
            var take = cost[i] + Math.Min(costSkip, costTake);
            costTake = costSkip;
            costSkip = take;
        }
        
        return Math.Min(costTake, costSkip);
    }
}

// Accepted - Uses O(n) space
public class Solution1 {
    public int MinCostClimbingStairs(int[] cost) {
        var n = cost.Length;
        var minCost = new int[n];
        minCost[0] = cost[0];
        minCost[1] = cost[1];
        
        for(int i=2; i<n; i++)
            minCost[i] = cost[i] + Math.Min(minCost[i-1], minCost[i-2]);
            
        return Math.Min(minCost[n-1], minCost[n-2]);
    }
}