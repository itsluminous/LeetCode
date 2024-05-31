class Solution:
    def singleNumber(self, nums: List[int]) -> List[int]:
        # get the xor value of all numbers
        allXor = 0
        for num in nums:
            allXor ^= num
        
        # find any position which has bit set
        # we are choosing the rightmost set bit, but idea is to find any bit which is set
        setBit = allXor & -allXor

        # we are sure that out of two numbers, one will have setBit = 0 and other will have setBit = 1
        # so we group all numbers in two categories : those with setBit = 1 and those with setBit = 0
        numWithSet = numWithoutSet = 0
        for num in nums:
            if (num & setBit) == 0: numWithSet ^= num
            else: numWithoutSet ^= num

        return [numWithSet, numWithoutSet]