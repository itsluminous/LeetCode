class Solution:
    def pickGifts(self, gifts: List[int], k: int) -> int:
        gifts = [-g for g in gifts]
        heapq.heapify(gifts)

        while k > 0:
            num = heapq.heappop(gifts)
            num = math.floor(math.sqrt(-num))
            heapq.heappush(gifts, -num)
            k -= 1

        remaining = -sum(gifts)
        return remaining