class Solution:
    def numWaterBottles(self, numBottles: int, numExchange: int) -> int:
        count = numBottles
        while numBottles >= numExchange:
            converted = numBottles // numExchange
            remaining = numBottles % numExchange
            count += converted

            numBottles = converted + remaining

        return count