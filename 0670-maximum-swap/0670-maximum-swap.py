class Solution:
    def maximumSwap(self, num: int) -> int:
        num_str = list(str(num))
        n = len(num_str)
        smallIdx = largeIdx = largestIdx = n-1

        for i in range(n-2, -1, -1):
            if num_str[i] > num_str[largestIdx]:
                largestIdx = i
            elif num_str[i] < num_str[largestIdx]:
                smallIdx = i
                largeIdx = largestIdx

        if smallIdx == n-1: return num # no change needed
        num_str[smallIdx], num_str[largeIdx] = num_str[largeIdx], num_str[smallIdx]
        return int(''.join(num_str))