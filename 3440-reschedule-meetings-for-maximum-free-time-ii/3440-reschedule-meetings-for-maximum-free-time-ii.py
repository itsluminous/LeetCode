class Solution:
    def maxFreeTime(self, eventTime: int, startTime: List[int], endTime: List[int]) -> int:
        n = len(startTime)
        
        # gap between all intervals
        gap = [0] * (n+1)
        gap[0] = startTime[0]
        gap[n] = eventTime - endTime[n-1]
        for i in range(1, n):
            gap[i] = startTime[i] - endTime[i-1]

        # biggest gap on right of any idx
        largestRight = [0] * (n+1)
        for i in range(n-1, -1, -1):
            largestRight[i] = max(largestRight[i+1], gap[i+1])
        
        # we also need to track biggest gap on left of any idx
        # but we can track that while forming ans, no need to do separately

        # now, for each interval, we have two options
        # 1. if there is any gap either on left or right where this interval can fit, throw it there
        # 2. just slide it left or right without jumping. like in Problem 3439
        ans = largestLeft = 0
        for i in range(n):
            duration = endTime[i] - startTime[i]
            # 1. try to place current interval somewhere on left or right
            if largestLeft >= duration or largestRight[i+1] >= duration:
                ans = max(ans, gap[i] + gap[i+1] + duration)
            
            # 2. just slide interval on left or right (no jumping)
            ans = max(ans, gap[i] + gap[i+1])
            largestLeft = max(largestLeft, gap[i])
        
        return ans