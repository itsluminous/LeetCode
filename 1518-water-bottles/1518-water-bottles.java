// optimized simulation
class Solution {
    public int numWaterBottles(int numBottles, int numExchange) {
        var count = numBottles;
        while(numBottles >= numExchange){
            var converted = numBottles / numExchange;
            var remaining = numBottles % numExchange;
            count += converted;

            numBottles = converted + remaining;
        }

        return count;
    }
}

// Accepted - Simulation
class SolutionSim {
    public int numWaterBottles(int numBottles, int numExchange) {
        var count = numBottles;
        while(numBottles >= numExchange){
            numBottles -= numExchange;  // remove empty bottles
            numBottles++;               // get one filled bottle
            count++;
        }

        return count;
    }
}