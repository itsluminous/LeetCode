class Solution:
    def minZeroArray(self, nums: List[int], queries: List[List[int]]) -> int:
        n, q, k, curr_sum = len(nums), len(queries), 0, 0
        prefix_sum = [0] * (n+1)

        for i, num in enumerate(nums):
            # keep using queries till we cannot qualify current num
            while curr_sum + prefix_sum[i] < num:
                if k == q: return -1    # exhausted all queries

                left, right, val = queries[k]
                k += 1

                # if the query ends before curr idx, it is useless
                # if the query start after curr idx, then it is useless now, but may be used later
                if right < i: continue

                # update prefix_sum with line sweeping algo (same as 3355. Zero Array Transformation I)
                prefix_sum[max(left, i)] += val
                prefix_sum[right+1] -= val
            curr_sum += prefix_sum[i]
        
        return k
