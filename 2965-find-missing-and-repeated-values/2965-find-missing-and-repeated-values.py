class Solution:
    def findMissingAndRepeatedValues(self, grid: List[List[int]]) -> List[int]:
        n = len(grid) ** 2
        currSum = dup = 0
        uniq = set()

        for row in grid:
            for num in row:
                if num in uniq:
                    dup = num
                else:
                    uniq.add(num)
                    currSum += num
        
        expectedSum = (n * (n + 1)) // 2
        missing = expectedSum - currSum
        return [dup, missing]