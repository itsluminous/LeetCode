class Solution:
    def minZeroArray(self, nums: List[int], queries: List[List[int]]) -> int:
        n, q = len(nums), len(queries)
        decr = [0] * (n+1)  # prefix sum of how much can be decremented at each index
        currMaxDecr = 0    # max decr allowed currently
        k = 0

        for i, num in enumerate(nums):
            # keep using queries till we cannot qualify current num
            while num > currMaxDecr + decr[i]:
                if k == q: return -1   # exhausted all queries, cannot make it 0

                # read k-th query
                l, r, val = queries[k]
                k += 1
                
                # if the query ends before curr idx, it is useless
                # if the query start after curr idx, then it is useless now, but may be used later
                if r < i: continue

                # apply the k-th query (line sweeping algo)
                decr[max(l, i)] += val
                if r < n-1: decr[r + 1] -= val
            currMaxDecr += decr[i]
        
        return k