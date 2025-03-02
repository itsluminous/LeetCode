class Solution:
    def mergeArrays(self, nums1: List[List[int]], nums2: List[List[int]]) -> List[List[int]]:
        len1, len2 = len(nums1), len(nums2)
        idx1 = idx2 = 0
        ans = []

        while idx1 < len1 and idx2 < len2:
            if nums1[idx1][0] == nums2[idx2][0]:
                ans.append([nums1[idx1][0], nums1[idx1][1] + nums2[idx2][1]])
                idx1 += 1
                idx2 += 1
            elif nums1[idx1][0] < nums2[idx2][0]:
                ans.append(nums1[idx1])
                idx1 += 1
            else:
                ans.append(nums2[idx2])
                idx2 += 1

        while idx1 < len1:
            ans.append(nums1[idx1])
            idx1 += 1

        while idx2 < len2:
            ans.append(nums2[idx2])
            idx2 += 1

        return ans