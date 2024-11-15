# the array after removing something will either start at 0, or end at n-1, or both
# so at least one end will be there for sure
class Solution:
    def findLengthOfShortestSubarray(self, arr: List[int]) -> int:
        n, lidx, ridx = len(arr), 0, len(arr)-1
        if n == 1: return 0    # already sorted
        
        # find index of where decreasing arr starting at n-1 ends
        while ridx > 0 and arr[ridx] >= arr[ridx-1]: ridx -= 1

        # find optimal idx in right part, to merge with left part
        removalLen = ridx
        while lidx < ridx and (lidx == 0 or arr[lidx-1] <= arr[lidx]):
            while ridx < n and arr[lidx] > arr[ridx]:
                ridx += 1
            removalLen = min(removalLen, ridx - lidx - 1)
            lidx += 1

        return removalLen

# Accepted - binary search
# the array after removing something will either start at 0, or end at n-1, or both
# so at least one end will be there for sure
class SolutionBS:
    def findLengthOfShortestSubarray(self, arr: List[int]) -> int:
        n, lidx, ridx = len(arr), 0, len(arr)-1
        if n == 1: return 0    # already sorted
        
        # find index of where increasing arr starting at 0 ends
        while lidx < n-1 and arr[lidx+1] >= arr[lidx]: lidx += 1

        # full arr is ascending
        if lidx == n-1: return 0
        
        # find index of where decreasing arr starting at n-1 ends
        while arr[ridx] >= arr[ridx-1]: ridx -= 1

        # best case - right array fits just next to left array
        if arr[ridx] >= arr[lidx]: return ridx - lidx - 1

        # find optimal idx in right part, to merge with left part
        sortedLen = lidx + 1
        for i in range(ridx, n):
            currLen = self.getMaxLen(arr, lidx, i)
            sortedLen = max(sortedLen, currLen)

        # remove anything which is not part of sorted array
        return n - sortedLen

    def getMaxLen(self, arr, end, idx):
        n, start = len(arr), 0
        rightLen = n - idx

        if arr[idx] >= arr[end]: return (end + 1) + rightLen
        if arr[idx] < arr[start]: return rightLen
        
        while start < end:
            mid = start + (end - start) // 2
            if arr[mid] <= arr[idx]: start = mid+1
            else: end = mid
        return start + rightLen