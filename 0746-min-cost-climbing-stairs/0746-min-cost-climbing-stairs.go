func minCostClimbingStairs(cost []int) int {
    take, notTake := cost[0], cost[1]
    for i:=2; i<len(cost); i++ {
        takeThis := cost[i] + min(take, notTake)
        take, notTake = notTake, takeThis
    }
    return min(take, notTake)
}