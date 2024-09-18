class Solution:
    def largestNumber(self, nums: List[int]) -> str:
        # handle edge case - when all numbers are 0, then return single 0
        if all(num == 0 for num in nums): return "0"

        # convert array to string
        str_nums = list(map(str, nums))

        # sort the strings with custom logic
        str_nums.sort(key=cmp_to_key(lambda s1, s2: (s2 + s1 > s1 + s2) - (s2 + s1 < s1 + s2)))

        # join all the strings
        return ''.join(str_nums)