class Solution:
    def maxEvents(self, events: List[List[int]]) -> int:
        lastDay = max(event[1] for event in events)
        
        events.sort()
        pq = []
        ans = idx = 0

        # emulate each passing day
        for day in range(1, lastDay + 1):
            # if event start day <= curr day, then it is eligible
            while idx < len(events) and events[idx][0] <= day:
                heappush(pq, events[idx][1])
                idx += 1

            # if event end time < curr day, then it is not eligible
            while pq and pq[0] < day:
                heappop(pq)
            
            # if there is somethig left in queue, then it is eligible
            # we pick the day with smallest end time
            if pq:
                heappop(pq)
                ans += 1

        return ans