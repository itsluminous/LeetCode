class Solution:
    def trap(self, height: List[int]) -> int:
        n, water = len(height), 0

        # find the maximum height on right side of an index
        largestOnRight = [0] * n
        for i in range(n-2, -1, -1):
            largestOnRight[i] = max(largestOnRight[i+1], height[i+1])

        largestOnLeft = height[0]
        for i in range(1, n):
            # water level for any index will be equal to min of largest block on left or right
            maxHeight = min(largestOnLeft, largestOnRight[i])
            largestOnLeft = max(largestOnLeft, height[i])

            # subtract height[i] from maxHeight to get actual water at that index
            if maxHeight > height[i]:
                water += maxHeight - height[i]

        return water