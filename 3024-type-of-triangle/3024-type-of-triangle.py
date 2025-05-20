class Solution:
    def triangleType(self, nums: List[int]) -> str:
        nums.sort()
        s1, s2, s3 = nums

        if s1 + s2 <= s3: return "none"  # can't form triangle
        if s1 == s3: return "equilateral"
        if s1 == s2 or s2 == s3: return "isosceles"
        return "scalene"