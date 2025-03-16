class Solution {
    public long repairCars(int[] ranks, int cars) {
        long low = 1, high = 1L * ranks[0] * cars * cars;   // high = let rank[0] repair all cars
        while(low < high){
            long mid = low + (high - low) / 2;
            if(canRepair(ranks, cars, mid))
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }

    private boolean canRepair(int[] ranks, int cars, long maxTime){
        for(var rank : ranks){
            var repairedCarsSq = maxTime / rank;
            cars -= (int)Math.sqrt(repairedCarsSq);
            if(cars <= 0) break;
        }

        return cars <= 0;
    }
}