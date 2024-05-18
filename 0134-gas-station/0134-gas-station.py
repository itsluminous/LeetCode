class Solution:
    def canCompleteCircuit(self, gas: List[int], cost: List[int]) -> int:
        totalFuel = currFuel = 0    # total fuel will be sum of all gas minus sum of all cost
        startIdx = 0

        for idx in range(len(gas)):
            totalFuel += (gas[idx] - cost[idx])
            currFuel += (gas[idx] - cost[idx])

            # if fuel is negative, then we can guarantee that all indexes before this cannot be start point
            # because a valid start point will always keep fuel in positive
            if currFuel < 0:
                currFuel = 0
                startIdx = idx+1
        
        if totalFuel < 0: return -1    # the consumption is more than gas earned
        return startIdx