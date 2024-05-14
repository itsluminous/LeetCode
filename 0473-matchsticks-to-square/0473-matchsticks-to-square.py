class Solution:
    def makesquare(self, matchsticks: List[int]) -> bool:
        k = 4  # need to divide the matchsticks into k equal groups
        if len(matchsticks) < k: return False

        totalSum = sum(matchsticks)
        if totalSum % k != 0: return False  # it can never be divided in 4

        # sort array in descending
        matchsticks.sort(reverse=True)

        sideSum = totalSum / k              # allowed sum of each side
        if matchsticks[0] > sideSum: return False  # one stick cannot exceed sideSum

        # try to split the matchsticks into k groups
        self.seen = [set() for _ in range(len(matchsticks) + 1)]
        return self.dfs(matchsticks, k, sideSum, 0, 0, 0)

    def dfs(self, matchsticks: List[int], k: int, targetSum: int, visited: int, currSum: int, idx: int):
        # if we have already seen this mask, then useless
        if visited in self.seen[k]: return False
        self.seen[k].add(visited)

        # all pending matchsticks can be put in one side, if we need only one side
        if k == 1: return True 
        
        # if current side is done, then look for other sides
        if currSum == targetSum: return self.dfs(matchsticks, k-1, targetSum, visited, 0, 0)

        # try to fit every remaining matchstick one by one to match targetSum
        for i in range(len(matchsticks)):
            mask = 1 << i
            if (visited & mask) == mask or (currSum + matchsticks[i]) > targetSum: continue
            visited |= mask
            if self.dfs(matchsticks, k, targetSum, visited, currSum + matchsticks[i], idx+1): return True
            visited ^= mask

        # not possible to make square with current setup
        return False