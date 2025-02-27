class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        intervals = sorted(intervals, key=lambda x : x[0])
        
        ans = [intervals[0]]
        for start, end in intervals:
            prevEnd = ans[-1][1]
            if start <= prevEnd:
                ans[-1][1] = max(end, prevEnd)
            else:
                ans.append([start, end])
        return ans