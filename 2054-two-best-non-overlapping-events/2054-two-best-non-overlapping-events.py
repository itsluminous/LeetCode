class Solution:
    def maxTwoEvents(self, events: List[List[int]]) -> int:
        # array to track which event started or ended at any given point
        times = []
        for start, end, value in events:
            times.append((start, True, value))  # time, is_start, value
            times.append((end+1, False, value)) # end+1 because events array is inclusive
        
        times.sort()    # sort by start time

        ans = max_till_now = 0
        for time, is_start, value in times:
            if is_start:
                # if we found a start array, then check if this + prev max is max ans
                ans = max(ans, max_till_now + value)
            else:
                # for end time, we just update max_till_now with curr value if this is bigger
                max_till_now = max(max_till_now, value)
        
        return ans