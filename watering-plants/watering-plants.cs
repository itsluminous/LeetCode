public class Solution {
    public int WateringPlants(int[] plants, int capacity) {
        int n = plants.Length, curr = capacity, steps = 0;
        for(int i=0; i<n; i++){
            // refill the can if you don't have enough water
            if(curr < plants[i]){
                steps += i*2;
                curr = capacity;
            }
            // water the plant i
            curr -= plants[i];
            steps++;
        }
        return steps;
    }
}