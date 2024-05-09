class Solution:
    def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
        happiness.sort(reverse=True)
        val = 0

        for i in range(len(happiness)):
            currHappiness = happiness[i] - i
            if currHappiness <= 0: break
            val += currHappiness

            k -= 1
            if k == 0: break

        return val