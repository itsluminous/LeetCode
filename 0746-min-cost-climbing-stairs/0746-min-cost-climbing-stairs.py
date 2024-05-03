class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        take, notTake = cost[0], cost[1]
        for i in range(2, len(cost)):
            takeThis = cost[i] +min(take, notTake)
            take, notTake = notTake, takeThis

        return min(take, notTake)