public class Solution {
    public int minCostClimbingStairs(int[] cost) {
        int take = cost[0], notTake = cost[1];
        for(var i=2; i<cost.length; i++){
            var takeThis = cost[i] + Math.min(take, notTake);
            take = notTake;
            notTake = takeThis;
        }

        return Math.min(take, notTake);
    }
}