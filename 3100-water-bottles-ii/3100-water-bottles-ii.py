class Solution:
    def maxBottlesDrunk(self, numBottles: int, numExchange: int) -> int:
        drank = numBottles
        empty = numBottles

        while(numExchange > 0 and empty >= numExchange):
            drank += 1
            empty = (empty - numExchange + 1);
            numExchange += 1
        
        return drank