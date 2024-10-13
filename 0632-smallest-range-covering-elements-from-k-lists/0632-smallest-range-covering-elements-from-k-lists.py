class Solution:
    def smallestRange(self, nums: List[List[int]]) -> List[int]:
        # create a minHeap to be able to get smallest element out of all lists
        minHeap = []   # the array will be [num, row, col]
        start, end, minRange = -1, nums[0][0], float('inf')

        # add first element from all lists to minHeap
        for r in range(len(nums)):
            end = max(end, nums[r][0])
            heapq.heappush(minHeap, [nums[r][0], r, 0])

        # loop until we have exhausted atleast one row in nums
        while len(minHeap) == len(nums):
            num, r, c = heapq.heappop(minHeap)
            
            # we found a smaller range
            if end - num < minRange:
                start = num
                minRange = end - start

            # if we exhausted all values in a row, then we need to stop
            if c+1 == len(nums[r]): break
            
            # else add the next element from that row to minHeap
            heapq.heappush(minHeap, [nums[r][c+1], r, c+1])
            end = max(end, nums[r][c+1])

        return [start, start+minRange]