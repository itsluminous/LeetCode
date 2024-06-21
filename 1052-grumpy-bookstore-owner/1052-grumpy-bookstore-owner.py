# maintain a sliding window of `minutes` size and keep track of how many extra are satisfied in that
class Solution:
    def maxSatisfied(self, customers: List[int], grumpy: List[int], minutes: int) -> int:
        n = len(customers)

        # how many can be satisfied without any trickery
        defaultSatisfied = 0
        for i in range(n):
            if grumpy[i] == 0: defaultSatisfied += customers[i]

        # now figure out how many can be satisfied by using secret technique
        maxExtraSatisfied = currExtraSatisfied = 0
        for i in range(minutes):
            if grumpy[i] == 1: currExtraSatisfied += customers[i]
        maxExtraSatisfied = currExtraSatisfied

        # try to shift window one by one and see how many exta we can satisfy
        left, right = 0, minutes
        while right < n:
            if grumpy[left] == 1: currExtraSatisfied -= customers[left]
            if grumpy[right] == 1: currExtraSatisfied += customers[right]

            maxExtraSatisfied = max(maxExtraSatisfied, currExtraSatisfied)
            left += 1
            right += 1
        
        return defaultSatisfied + maxExtraSatisfied