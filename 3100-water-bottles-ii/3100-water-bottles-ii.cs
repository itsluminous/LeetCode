public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int drank = numBottles, empty = numBottles;
        
        while(numExchange > 0 && empty >= numExchange){
            drank++;
            empty = (empty - numExchange + 1);
            numExchange++;
        }
        return drank;
    }
}

