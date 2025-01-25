class Solution:
    def lexicographicallySmallestArray(self, nums: List[int], limit: int) -> List[int]:
        # tuples of num and its index
        numIdx = [] 
        for i, num in enumerate(nums):
            numIdx.append((num, i))
        
        # sort numIdx asc based on num value
        numIdx = sorted(numIdx, key=lambda k: k[0])

        # group numbers into different sets, based on their difference
        sets = [[numIdx[0]]]
        for i in range(1, len(nums)):
            if numIdx[i][0] - numIdx[i-1][0] > limit:
                sets.append([numIdx[i]])    # separate set
            else:
                sets[-1].append(numIdx[i])   # part of prev set
        
        for sett in sets:
            # sort indexes of all elements in curr set
            indexes = []
            for num, idx in sett: indexes.append(idx)
            indexes.sort()

            # now put smallest no. at smallest index, then next no. and so on
            for i, idx in enumerate(indexes):
                nums[idx] = sett[i][0]
        
        return nums

