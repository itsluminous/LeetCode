class Solution:
    def sortJumbled(self, mapping: List[int], nums: List[int]) -> List[int]:
        n = len(nums)
        
        # create a mapped array
        mapped = []
        for num in nums:
            numMap, mul = 0, 1
            while num > 9:
                numMap += mul * mapping[num % 10]
                num //= 10
                mul *= 10
            numMap += mul * mapping[num % 10]
            mapped.append(numMap)

        # sort the indexes as per mapped value
        indices = list(range(n))
        indices.sort(key=lambda i: mapped[i])

        # return the sorted nums
        sorted_nums = [nums[i] for i in indices]
        return sorted_nums