class Solution:
    def minDominoRotations(self, tops: List[int], bottoms: List[int]) -> int:
        n = len(tops)
        topFreq, botFreq, sameFreq = [0] * 7, [0] * 7, [0] * 7

        # count freq of each num in both rows respectively
        for i in range(n):
            t, b = tops[i], bottoms[i]
            topFreq[t] += 1
            botFreq[b] += 1
            if t == b: sameFreq[t] += 1

        # now check which of 6 dice faces can be made
        for i in range(1, 7):
            if topFreq[i] + botFreq[i] - sameFreq[i] == n:  # if this face has n occurence
                return n - max(topFreq[i], botFreq[i])      # make it on row with max count of it  

        return -1

# Accepted - try to make num1 & num2 in top row and bot row
class SolutionSimulation:
    def minDominoRotations(self, tops: List[int], bottoms: List[int]) -> int:
        FAIL = float(inf)
        top1, top1Rot = tops[0], 0
        top2, top2Rot = bottoms[0], 1
        bot1, bot1Rot = bottoms[0], 0
        bot2, bot2Rot = tops[0], 1

        for i in range(1, len(tops)):
            # make tops[0] in top row
            if tops[i] != top1 and bottoms[i] != top1: top1Rot = FAIL
            elif top1Rot != FAIL and tops[i] != top1: top1Rot += 1

            # make bottoms[0] in top row
            if tops[i] != top2 and bottoms[i] != top2: top2Rot = FAIL
            elif top2Rot != FAIL and tops[i] != top2: top2Rot += 1

            # make bottoms[0] in bottom row
            if bottoms[i] != bot1 and tops[i] != bot1: bot1Rot = FAIL
            elif bot1Rot != FAIL and bottoms[i] != bot1: bot1Rot += 1
            
            # make tops[0] in bottom row
            if bottoms[i] != bot2 and tops[i] != bot2: bot2Rot = FAIL
            elif bot2Rot != FAIL and bottoms[i] != bot2: bot2Rot += 1

            # if neither is possible, then early exit
            if top1Rot == FAIL and top2Rot == FAIL and bot1Rot == FAIL and bot2Rot == FAIL:
                return -1

        # find smallest rotation
        topRot = min(top1Rot, top2Rot)
        botRot = min(bot1Rot, bot2Rot)
        return min(topRot, botRot)