class Solution:
    def maxScore(self, nums1: List[int], nums2: List[int], k: int) -> int:
        n = len(nums1)
        
        # merge nums1 & nums2 based on index
        combined = [(nums1[i], nums2[i]) for i in range(n)]

        # sort this combined array by nums2 value, descending
        # When we iterate over this sorted array, we know that smallest n2 is curr index
        combined.sort(key = lambda x: x[1], reverse = True)

        # priority queue to track smallest in nums1, so that it can be removed if needed
        pq = []
        ans = num1Sum = 0

        for (n1, n2) in combined:
            num1Sum += n1
            
            heappush(pq, n1)
            if len(pq) > k: num1Sum -= heappop(pq)   # remove smallest num1
            if len(pq) == k: ans = max(ans, num1Sum * n2)

        return ans