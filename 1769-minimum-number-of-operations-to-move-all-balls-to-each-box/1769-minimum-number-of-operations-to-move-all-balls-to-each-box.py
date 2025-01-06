class Solution:
    def minOperations(self, boxes: str) -> List[int]:
        n = len(boxes)
        ans = [0] * n

        ballsOnLeft = ballsOnRight = 0
        movesFromLeft = movesFromRight = 0

        # count moves from left & right side
        for i in range(n):
            ans[i] +=  movesFromLeft
            ballsOnLeft += int(boxes[i])
            movesFromLeft += ballsOnLeft

            j = n - i - 1
            ans[j] += movesFromRight
            ballsOnRight += int(boxes[j])
            movesFromRight += ballsOnRight
        
        return ans