class Solution:
    def longestSubarray(self, nums: List[int], limit: int) -> int:
        # min & max heap to store the actual number and its index
        maxQ, minQ = [], []
        longest, idx = 1, 0

        for i, num in enumerate(nums):
            heapq.heappush(maxQ, [-num, i])
            heapq.heappush(minQ, [num, i])

            # if the diff between min & max in curr window exceeds limit, then increment the left index
            while -maxQ[0][0] - minQ[0][0] > limit:
                idx = min(maxQ[0][1], minQ[0][1]) + 1                # new left idx
                while maxQ and maxQ[0][1] < idx: heapq.heappop(maxQ) # remove invalid max
                while minQ and minQ[0][1] < idx: heapq.heappop(minQ) # remove invalid min
            longest = max(longest, i - idx + 1)

        return longest