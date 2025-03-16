public class Solution {
    public long RepairCars(int[] ranks, int cars) {
        long low = 1, high = 1L * ranks[0] * cars * cars;   // high = let rank[0] repair all cars
        while(low < high){
            long mid = low + (high - low) / 2;
            if(CanRepair(ranks, cars, mid))
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }

    private bool CanRepair(int[] ranks, int cars, long maxTime){
        foreach(var rank in ranks){
            var repairedCarsSq = maxTime / rank;
            cars -= (int)Math.Sqrt(repairedCarsSq);
            if(cars <= 0) break;
        }

        return cars <= 0;
    }
}