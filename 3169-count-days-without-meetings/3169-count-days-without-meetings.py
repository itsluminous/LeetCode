class Solution:
    def countDays(self, days: int, meetings: List[List[int]]) -> int:
        meetings.sort()
        freeDays = prevEnd = 0

        # merge intervals, and track free days when new interval is started
        for currStart, currEnd in meetings:
            if currStart > prevEnd:
                freeDays += currStart - prevEnd - 1
            prevEnd = max(prevEnd, currEnd)

        # include days we are free after last meeting
        freeDays += days - prevEnd
        return freeDays