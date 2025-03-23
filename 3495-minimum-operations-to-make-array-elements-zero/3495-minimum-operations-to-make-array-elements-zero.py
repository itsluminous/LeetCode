class Solution:
    def minOperations(self, queries: List[List[int]]) -> int:
        ans = 0
        
        for start, end in queries:
            ops = 0
            pow4prev = 1 # initially d = 0, so 4 ^ d = 1

            # d = power of 4
            # 4^15 > 1e9, so enough to cover all number ranges
            for d in range(1, 16):
                pow4curr = pow4prev * 4

                # what is the first no. in query range that we can cover
                left = max(start, pow4prev)
                
                # what is the last no. in query range that we can cover (with next power)
                right = min(end, pow4curr - 1)   # pow4curr - 1 because pow4curr will be used as start for next loop

                # if we can cover some numbers, then add them to ops
                # each number in range will need to be divided "d" times by 4
                if right >= left:
                    ops += (right - left + 1) * d
                
                # set up for next loop
                pow4prev = pow4curr

            # since we can divide two nums in one go, so actual ops will be Ceil(ops / 2)
            ans += (ops + 1) // 2

        return ans