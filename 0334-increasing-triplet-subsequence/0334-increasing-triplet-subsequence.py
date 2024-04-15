class Solution:
    def increasingTriplet(self, nums: List[int]) -> bool:
        n = len(nums)
        first = second = float(inf)

        for num in nums:
            if num <= first: first = num            # first element of sequence found
            elif num <= second: second = num        # second element of sequence found
            else: return True                        # third element of sequence found
        return False