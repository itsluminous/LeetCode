class Solution:
    def kthSmallestPrimeFraction(self, arr: List[int], k: int) -> List[int]:
        n = len(arr)
        pq = []

        for i in range(n):
            for j in range(i+1, n):
                fraction = (arr[i]/arr[j], (arr[i], arr[j]))
                heappush(pq, fraction)
        
        for _ in range(k-1): heappop(pq)
        return heappop(pq)[1]