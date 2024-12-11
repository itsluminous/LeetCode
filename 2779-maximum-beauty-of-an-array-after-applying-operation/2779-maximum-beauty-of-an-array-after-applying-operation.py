class Solution:
    def maximumBeauty(self, nums: List[int], k: int) -> int:
        maxVal = max(nums)

        # prefix sum array to know when a range starts and when it ends
        pre = [0] * (maxVal+1)
        for num in nums:
            start, end = max(num-k, 0), num + k + 1
            pre[start] += 1
            if end <= maxVal:
                pre[end] -= 1
        
        # find the index with most overlap
        ans = curr = 0
        for num in pre:
            curr += num
            ans = max(ans, curr)
        
        return ans
        