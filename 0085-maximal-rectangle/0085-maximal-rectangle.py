# this is basically same problem as #84
# for each row in matrix, create a histogram and then find largest area in histogram
# explaination video : https://www.youtube.com/watch?v=dAVF2NpC3j4
class Solution:
    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        m, n = len(matrix), len(matrix[0])
        max_area = 0
        heights = [0]*n

        for i in range(m):
            for j in range(n):
                if matrix[i][j] == '0': heights[j] = 0
                else: heights[j] += 1
            area = self.largestRectangleArea(heights)
            max_area = max(max_area, area)

        return max_area

    # function to find largest square in a histogram
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
        max_area = 0
        for i in range(n):
            area = heights[i] * (rightLessIndex[i] - leftLessIndex[i] - 1)
            max_area = max(max_area, area)
        
        return max_area