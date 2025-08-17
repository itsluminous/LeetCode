class Solution:
    def new21Game(self, n: int, k: int, maxPts: int) -> float:
        if k == 0 or n >= k + maxPts: return 1 # score will never cross n in this case
        ans, wsum = 0.0, 1.0   # wsum = sum of sliding window of size maxPts
        prob = [1.0] + [0.0] * n # probability of getting score 1 to n+1

        for i in range(1, n+1):
            prob[i] = wsum / maxPts    # (sum of window of size maxPts) / maxPts
            if i < k: wsum += prob[i]    # this is not terminal state
            else: ans += prob[i]          # terminal state, it cannot be explored further

            if i >= maxPts: wsum -= prob[i-maxPts] # subtract if left side will go out of sliding window
        return ans