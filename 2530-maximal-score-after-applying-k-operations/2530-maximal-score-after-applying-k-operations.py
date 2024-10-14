class Solution:
    def maxKelements(self, nums: List[int], k: int) -> int:
        maxHeap = [-num for num in nums]
        heapq.heapify(maxHeap)

        score = 0
        for _ in range(k):
            num = -heapq.heappop(maxHeap)
            score += num
            heapq.heappush(maxHeap, -ceil(num / 3))

        return score