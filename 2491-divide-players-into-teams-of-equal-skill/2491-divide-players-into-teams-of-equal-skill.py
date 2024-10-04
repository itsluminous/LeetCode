class Solution:
    def dividePlayers(self, skill: List[int]) -> int:
        n = len(skill)
        teamCount, total = n//2, 0
        freq = [0] * 1001
        for sk in skill:
            total += sk
            freq[sk] += 1

        if total % teamCount != 0: return -1
        teamSkill = total // teamCount
        
        chemistry = 0
        for sk in skill:
            partner = teamSkill - sk
            if freq[partner] == 0: return -1
            chemistry += (sk * partner)
            freq[partner] -= 1

        return chemistry // 2 # because of double counting of each pair