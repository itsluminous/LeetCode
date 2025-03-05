class Solution:
    def maxChunksToSorted(self, arr: List[int]) -> int:
        n, chunks = len(arr), 0
        
        # min number seen on right side
        minOnRight = [arr[-1]] * n  
        for i in range(n-2, -1, -1):
            minOnRight[i] = min(arr[i], minOnRight[i+1])
        
        maxOnLeft = 0   # max number seen on left side
        for i in range(n-1):
            maxOnLeft = max(maxOnLeft, arr[i])
            if maxOnLeft <= minOnRight[i+1]:
                chunks += 1
        
        return 1 + chunks   # add 1 because our loop does not include last element
