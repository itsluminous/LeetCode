from sortedcontainers import SortedSet

class Solution:
    def smallestChair(self, times: List[List[int]], targetFriend: int) -> int:
        targetStart = times[targetFriend][0]
        times.sort(key=lambda x: x[0])
        
        leavingQueue = []
        avalableChairs = SortedSet()

        nextChair = 0
        for time in times:
            start, end = time
            while leavingQueue and start >= leavingQueue[0][0]:
                avalableChairs.add(heapq.heappop(leavingQueue)[1])
            
            currChair = 0
            if avalableChairs:
                currChair = avalableChairs[0]
                avalableChairs.remove(currChair)
            else:
                currChair = nextChair
                nextChair += 1

            if start == targetStart: return currChair
            heapq.heappush(leavingQueue, [end, currChair])

        return 0