# INTUTION : the edges array is irrelevant
# if every node is connected in the tree (transitively), then we can pick any two nodes and xor them
# because (a ^ k) ^ k = a
# so if I have edge [0,1] & [0,2] => here [1,2] are not even connected directly
# but still if I do => [0^k, 1^k] and then [0^k, 2^k] then finally number will be [0, 1^k], [0, 2^k]
# so we were able to xor [1,2] even though there is no direct connection

# with above knowledge, we simply perform backtracking with memoization
class Solution:
    def maximumValueSum(self, nums: List[int], k: int, edges: List[List[int]]) -> int:
        n = len(nums)
        self.dp = [[-1, -1] for _ in range(n)]    # [node, XORed even till now or not]
        
        return self.maximumValueSum_helper(nums, k, 0, 1)  # isEven = 1 because we have XORed 0 nodes, which is even
    
    def maximumValueSum_helper(self, nums, k, curr_idx, is_even):
        n = len(nums)
        
        # base case
        # if any node is xored odd times, then it changes value
        # even times means it will have its original value
        if curr_idx == n:
            return 0 if is_even == 1 else float('-inf')
        
        if self.dp[curr_idx][is_even] != -1:
            return self.dp[curr_idx][is_even]
        
        # find out whether xoring curr num is better or not
        not_xor = nums[curr_idx] + self.maximumValueSum_helper(nums, k, curr_idx + 1, is_even)
        xor = (nums[curr_idx] ^ k) + self.maximumValueSum_helper(nums, k, curr_idx + 1, 1 - is_even)
        
        self.dp[curr_idx][is_even] = max(xor, not_xor)
        return self.dp[curr_idx][is_even]


# Accepted - O(n logn)
# since (a ^ k) ^ k = a
# so edges array is actually irrelevant.
# we can pick any two nums and xor both of them, they don't have to be connected directly.
class SolutionGreedy:
    def maximumValueSum(self, nums: List[int], k: int, edges: List[List[int]]) -> int:
        n = len(nums)
        num_sum = 0
        xor_diff = [0] * n   # how much extra we get if we xor nums[i]
        for i in range(n):
            num_sum += nums[i]
            xor_diff[i] = (nums[i] ^ k) - nums[i]  # negative value if xor gives smaller number
        
        # include the index pairs with biggest diffs first
        xor_diff.sort()
        i = n - 1
        while i > 0:
            pair_sum = xor_diff[i] + xor_diff[i-1]
            if pair_sum <= 0:
                break
            num_sum += pair_sum
            i -= 2
        
        return num_sum