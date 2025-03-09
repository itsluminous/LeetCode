class Solution:
    def findMaxSum(self, nums1: List[int], nums2: List[int], k: int) -> List[int]:
        n = len(nums1)
        ans = [0] * n

        # combine nums1 & nums2 into a 2d array : [idx, nums1, nums2]
        idxNums = [[i, nums1[i], nums2[i]] for i in range(n)]
        idxNums.sort(key=lambda row:row[1])

        currSum = 0
        pq = []
        for i in range(n):
            idx, n1, n2 = idxNums[i]
            # if curr num is same as prev, copy result
            if i > 0 and n1 == idxNums[i-1][1]:
                ans[idx] = ans[idxNums[i-1][0]]
            else:
                ans[idx] = currSum
            currSum += n2
            
            # maintain sum of last k elements only
            heappush(pq, n2)
            if len(pq) > k:
                currSum -= heappop(pq)

        return ans