class Solution:
    def minGroups(self, intervals: List[List[int]]) -> int:
        # sort by start time
        intervals.sort(key=lambda i:i[0])

        # minHeap to track endingTime for each interval group
        endTime = []

        for start,end in intervals:
            # if the end time of smallest range is smaller than current interval
            # then we can add current interval to same group, i.e. replace end time of that with current
            # else we need to create a new group
            if endTime and endTime[0] < start:
                heapq.heappop(endTime)
            heapq.heappush(endTime, end)

        return len(endTime)