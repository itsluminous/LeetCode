class Solution:
    def minOperations(self, nums: List[int]) -> int:
        steps = 0
        stack = []   # monotonnically increasing stack

        for num in nums:
            # pop all numbers bigger than curr, as they cannot be grouped with anyone else
            while stack and stack[-1] > num: stack.pop()
            
            if num == 0: continue  # no operation needed for 0
            if stack and stack[-1] == num: continue   # no extra operation needed for same num
            stack.append(num)
            steps += 1

        return steps