class Solution:
    def relativeSortArray(self, arr1: List[int], arr2: List[int]) -> List[int]:
        freq = [0] * 1001

        # find freq of each number in arr1
        for num in arr1:
            freq[num] += 1
        
        # put all matching nums from arr2 in final ans
        pos = 0
        for num in arr2:
            count = freq[num]
            freq[num] = 0
            for i in range(count):
                arr1[pos] = num
                pos += 1

        # sort remaining nums and put in ans
        for num in range(1001):
            count = freq[num]
            for i in range(count):
                arr1[pos] = num
                pos += 1

        return arr1