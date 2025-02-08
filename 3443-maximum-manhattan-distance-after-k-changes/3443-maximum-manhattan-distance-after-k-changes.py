class Solution:
    def maxDistance(self, s: str, k: int) -> int:
        count = [0] * 100
        maxdist = 0
        for i in range(0, len(s)):
            count[ord(s[i])] += 1
            oppositeDirs = min(count[ord('N')], count[ord('S')]) + min(count[ord('E')], count[ord('W')])
            # no. of dir changes = (i+1), and we can at most revert oppositeDirs moves in this
            # each dir removal have double impact on manhattan distance, hence * 2
            dist = i + 1 - (2 * oppositeDirs)
            # reverting oppositeDirs moves will also add same moves on opposite direction
            # hence multiply by 2
            # but we can only revert max of k moves
            dist += 2 * min(k, oppositeDirs)
            maxdist = max(maxdist, dist)
        
        return maxdist
            