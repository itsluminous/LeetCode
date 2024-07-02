class Solution:
    def intersect(self, nums1: List[int], nums2: List[int]) -> List[int]:
        freq = [0] * 1001
        for num in nums1:
            freq[num] += 1
        
        ans = []
        for num in nums2:
            if freq[num] > 0:
                ans.append(num)
                freq[num] -= 1

        return ans