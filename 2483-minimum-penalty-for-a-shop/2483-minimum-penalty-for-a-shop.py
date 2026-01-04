class Solution:
    def bestClosingTime(self, customers: str) -> int:
        currPenalty = minPenalty = minIdx = 0

        for i, cust in enumerate(customers):
            if cust == 'Y': currPenalty -= 1
            else: currPenalty += 1

            if currPenalty < minPenalty:
                minPenalty = currPenalty
                minIdx = i+1

        return minIdx