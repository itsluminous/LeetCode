class Solution:
    def kidsWithCandies(self, candies: List[int], extraCandies: int) -> List[bool]:
        max_val = max(candies)

        ans = []
        for i,candy in enumerate(candies):
            if candy + extraCandies >= max_val:
                ans.append(True)
            else:
                ans.append(False)
        return ans