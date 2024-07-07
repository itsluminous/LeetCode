public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
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