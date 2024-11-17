class Solution:
    def shortestSubarray(self, nums: List[int], k: int) -> int:
        n, shortest = len(nums), len(nums)+1
        
        # calculate prefix sum
        # in prefix sum, we know that sum of nums from l to r is pre[r] - pre[l]
        pre = [0] * (n+1)
        for i in range(n):
            pre[i+1] = pre[i] + nums[i]

        # create an increasing double ended queue
        dq = collections.deque()
        for i in range(n+1):
            # if sum till i >= k, then try to reduce the array size from left side, to get smallest array
            while dq and pre[i] - pre[dq[0]] >= k:
                shortest = min(shortest, i - dq.popleft())
            
            # to keep the dequeue in increasing order, remove elements from right which are >= pre[i]
            # the removed nums are useless to us because they will only yield longer subarrays
            while dq and pre[i] <= pre[dq[-1]]:
                dq.pop()
            
            # append the current index in dequeue
            dq.append(i)

        if shortest == n+1: return -1
        return shortest