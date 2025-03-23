class Solution:
    def minTime(self, skill: List[int], mana: List[int]) -> int:
        n, m = len(skill), len(mana)

        # completionTime = time when each wizard completed potion
        completionTime = [0] * n
        completionTime[0] = skill[0] * mana[0]
        for i in range(1, n):
            completionTime[i] = completionTime[i-1] + skill[i] * mana[0]

        # now for potion 1 onwards, find out time taken
        for p in range(1, m):
            # a wizard can start either after finishing time of prev potion or after prev wizard hands over
            completionTime[0] += skill[0] * mana[p]
            for i in range(1, n):
                completionTime[i] = max(completionTime[i], completionTime[i-1]) + skill[i] * mana[p]

            # retrospectively update timings for prev wizards
            for i in range(n-2, -1, -1):
                completionTime[i] = completionTime[i+1] - skill[i+1] * mana[p]

        # ans will be time when last wizard finishes last potion
        return completionTime[-1]