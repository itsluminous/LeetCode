class Solution:
    def maxDistance(self, arrays: List[List[int]]) -> int:
        smallest, biggest, maxDist = 10001, -10001, 0
        for arr in arrays:
            maxDist = max(maxDist, biggest - arr[0])
            maxDist = max(maxDist, arr[-1] - smallest)
            smallest = min(smallest, arr[0])
            biggest = max(biggest, arr[-1])

        return maxDist