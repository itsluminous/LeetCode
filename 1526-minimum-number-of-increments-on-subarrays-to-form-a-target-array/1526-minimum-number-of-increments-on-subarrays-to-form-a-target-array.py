class Solution:
    def minNumberOperations(self, target: List[int]) -> int:
        ops = incr = 0
        for num in target:
            if num > incr:
                ops += (num - incr)
            incr = num
        return ops