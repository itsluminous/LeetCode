class Solution:
    def kthSmallestProduct(self, nums1: List[int], nums2: List[int], k: int) -> int:
        # Step 1 : split nums1 & nums2 into positive and negative numbers list
        n1n, n1p = [], [] # negative and positive from nums1
        for num in nums1:
            if num < 0: n1n.append(num * -1)
            else: n1p.append(num)

        n2n, n2p = [], [] # negative and positive from nums2
        for num in nums2:
            if num < 0: n2n.append(num * -1)
            else: n2p.append(num)

        # Step 2 : Sort the split list (positive will already be sorted, so sort neg only)
        n1n.sort()
        n2n.sort()

        # Step 3 : if negative numbers are less than k, we can easily skip all of them
        negNums = len(n1n) * len(n2p) + len(n1p) * len(n2n)
        sign = 1
        if negNums < k:
            k -= negNums
        else:
            k = negNums - k + 1
            sign = -1
            n2n, n2p = n2p, n2n # swap n2n and n2p so that later we look at negative numbers only

        # Step 4 : Binary search the answer
        left, right = 0, 10_000_000_001
        while left < right:
            mid = left + (right - left) // 2
            if k <= self.check(n1n, n2n, mid) + self.check(n1p, n2p, mid):
                right = mid
            else:
                left = mid + 1

        return sign * left

    def check(self, nums1, nums2, val):
        total = 0
        j = len(nums2) - 1

        # move j to left in nums2, till product is more than val
        for n1 in nums1:
            while j >= 0 and n1 * nums2[j] > val:
                j -= 1
            total += j+1

        return total