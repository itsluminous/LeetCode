class Solution:
    def matchPlayersAndTrainers(self, players: List[int], trainers: List[int]) -> int:
        players.sort()
        trainers.sort()

        ans = t = 0
        for p in players:
            while t < len(trainers) and trainers[t] < p: t += 1
            if t == len(trainers): break
            ans += 1
            t += 1
        return ans