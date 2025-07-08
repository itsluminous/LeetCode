class Solution:
    def maxValue(self, events: List[List[int]], k: int) -> int:
        events.sort(key=lambda e: e[0])

        # dp = max value possible when we reach index i with k selections left
        self.dp = [[-1] * (k + 1) for _ in range(len(events))]
        self.events = events
        return self.dfs(0, k)
    
    def dfs(self, idx: int, k: int) -> int:
        if k == 0 or idx == len(self.events): return 0
        if self.dp[idx][k] != -1: return self.dp[idx][k]
        
        # find the index of the first event that starts after the current one ends
        next_idx = self.binary_search(self.events[idx][1])
        
        # we can either skip the current event, or take it and then explore further
        skip = self.dfs(idx + 1, k)
        take = self.events[idx][2] + self.dfs(next_idx, k - 1)
        self.dp[idx][k] = max(skip, take)
        return self.dp[idx][k]

    def binary_search(self, day: int) -> int:
        # binary search for the first event whose start time is > current event's end time
        left, right = 0, len(self.events)
        while left < right:
            mid = left + (right - left) // 2
            if self.events[mid][0] <= day:
                left = mid + 1
            else:
                right = mid
        return left