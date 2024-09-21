class Solution:
    def lexicalOrder(self, n: int) -> List[int]:
        ans = []

        def helper(curr):
            if curr > n: return
        
            ans.append(curr)
            helper(curr * 10)

            # we don't want to repeat a number ending with 0 which is already covered
            if curr % 10 != 9:
                helper(curr + 1)
        
        helper(1)
        return ans