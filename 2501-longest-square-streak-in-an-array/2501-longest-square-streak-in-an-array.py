class Solution:
    def longestSquareStreak(self, nums: List[int]) -> int:
        streaks = {} # key = number, val = longest streak including it
        longestStreak = 0

        nums.sort()
        for num in nums:
            sq = num ** 0.5
            sqf = int(sq)

            # if it is a whole number
            if sq == sqf and sqf in streaks:
                streaks[num] = streaks[sqf] + 1
                longestStreak = max(longestStreak, streaks[num])
            else:
                streaks[num] = 1

        return longestStreak if longestStreak > 1 else -1