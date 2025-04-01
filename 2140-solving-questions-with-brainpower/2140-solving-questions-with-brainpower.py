class Solution:
    def mostPoints(self, questions: List[List[int]]) -> int:
        n = len(questions)
        
        # calculate max points achievable when starting from index i
        maxPossible = 0
        maxPoints = [0] * n
        for i in range(n-1, -1, -1):
            points, brainpower = questions[i]
            
            # score if we include curr point
            maxPoints[i] = points
            nextIdx = i + brainpower + 1
            if nextIdx < n:
                maxPoints[i] += maxPoints[nextIdx]
            
            # if the score after including curr point is bad, skip it
            if maxPoints[i] < maxPossible: maxPoints[i] = maxPossible
            else: maxPossible = maxPoints[i]

        return maxPossible