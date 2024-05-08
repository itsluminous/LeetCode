class Solution:
    def findRelativeRanks(self, score: List[int]) -> List[str]:
        toppers = ['Gold Medal', 'Silver Medal', 'Bronze Medal']
        n, position, maxScore = len(score), 1, max(score)

        # make an array of same size as max score, then place all players in that array based on score
        scoreToIdx = [-1] * (maxScore+1)
        for i in range(n): scoreToIdx[score[i]] = i

        # now traverse array from right to left and fill the rank array
        rank = [''] * n
        for i in range(maxScore, -1, -1):
            if scoreToIdx[i] == -1: continue

            idx = scoreToIdx[i]
            if position <= 3: rank[idx] = toppers[position-1]
            else: rank[idx] = str(position)
            position += 1
        
        return rank