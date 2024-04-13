class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        n = len(heights)
        leftLessIndex, rightLessIndex = [-1]*n, [n]*n
        
        # for each bar, find the point on left where we get lesser sized bar
        for i in range(n):
            curr = i-1
            while curr >= 0 and heights[curr] >= heights[i]:
                curr = leftLessIndex[curr]
            leftLessIndex[i] = curr
        
        # for each bar, find the point on right where we get lesser sized bar
        for i in range(n-2, -1, -1):
            curr = i+1
            while curr < n and heights[curr] >= heights[i]:
                curr = rightLessIndex[curr]
            rightLessIndex[i] = curr
        
        # now using this data, find max rectangle
        max_area = 0;
        for i in range(n):
            area = heights[i] * (rightLessIndex[i] - leftLessIndex[i] - 1)
            max_area = max(max_area, area)
        
        return max_area