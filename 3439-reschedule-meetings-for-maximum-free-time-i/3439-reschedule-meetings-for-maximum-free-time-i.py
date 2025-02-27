class Solution:
    def maxFreeTime(self, eventTime: int, k: int, startTime: List[int], endTime: List[int]) -> int:
        # how much max can we get by rearranging first k meetings
        free = 0
        for i in range(k):
            free += self.getEmptyOnLeft(startTime, endTime, i)
        
        maxFree = free + self.getEmptyOnRight(startTime, endTime, eventTime, k-1)

        # now slide that k window one by one
        l, r = 0, k
        while r < len(startTime):
            free -= self.getEmptyOnLeft(startTime, endTime, l)
            free += self.getEmptyOnLeft(startTime, endTime, r)
            maxFree = max(maxFree, free + self.getEmptyOnRight(startTime, endTime, eventTime, r))
            l, r = l+1, r+1

        return maxFree

    def getEmptyOnLeft(self, startTime, endTime, idx):
        if idx == 0:
            return startTime[idx] - 0
        return startTime[idx] - endTime[idx-1]

    def getEmptyOnRight(self, startTime, endTime, eventTime, idx):
        if idx == len(startTime) - 1:
            return eventTime - endTime[idx]
        return startTime[idx+1] - endTime[idx]