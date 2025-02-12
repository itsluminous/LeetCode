class Solution:
    MOD = 1_000_000_007

    def minMaxSums(self, nums: List[int], k: int) -> int:
        # it's subsequence, order won't matter
        nums.sort()
        n = len(nums)

        # dp to cache C(n,k) i.e. choose k elements from a set of n elements
        self.dp = [[-1] * (k+1) for _ in range(n+1)]
        
        ans = 0
        for i in range(n):
            maxSum = (nums[i] * self.count(i, k)) % self.MOD     # cases where curr num is max in list
            minSum = (nums[i] * self.count(n-i-1, k)) % self.MOD # cases where curr num is min in list
            ans = (ans + maxSum + minSum) % self.MOD

        return ans

    # count is function to choose k elements from a set of n elements
    # count(n, k) is same as nCk i.e. n!/k!(n-k)!
    # in other words, C(n,k) = C(n−1,k) + C(n−1,k−1)
    def count(self, n: int, k: int) -> int:
        if k == 1 or n == 0: return 1  # only one way to pick
        if self.dp[n][k] != -1: return self.dp[n][k]
        self.dp[n][k] = (self.count(n-1, k) + self.count(n-1, k-1)) % self.MOD
        return self.dp[n][k]

# more on binomial coefficients
# i.e. why C(n,k) = C(n−1,k) + C(n−1,k−1)
# C(n,k) means choosing k elements from a set of n elements
# if I decided to not use n-th element, and pick from remaining ones, it would be C(n-1, k)
# and if I decided that n-th element will be picked for sure, and remaining k-1 will be picked from n-1, then it is C(n-1, k-1)
# hence, choosing k elements from n elements = (k elements from n-1) + (k-1 elements from n-1 elements)
# C(n,k) = C(n−1,k) + C(n−1,k−1)