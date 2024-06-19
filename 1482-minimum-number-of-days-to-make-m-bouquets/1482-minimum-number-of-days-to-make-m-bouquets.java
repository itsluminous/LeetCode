class Solution {
    public int minDays(int[] bloomDay, int m, int k) {
        var flowersNeeded = (long) m * k;
        var totalFlowers = bloomDay.length;
        if(totalFlowers < flowersNeeded) return -1;

        // find the earliest we can start harvesting, and also last date
        int minDay = Integer.MAX_VALUE, maxDay = 0;
        for(var bd : bloomDay){
            minDay = Math.min(minDay, bd);
            maxDay = Math.max(maxDay, bd);
        }
        if(flowersNeeded == totalFlowers) return maxDay;
        
        // now, try to find optimal day between minDay & maxDay
        while(minDay < maxDay){
            var mid = minDay + (maxDay - minDay) / 2;
            if(canHarvest(bloomDay, m, k, mid))
                maxDay = mid;
            else
                minDay = mid + 1;
        }

        return minDay;
    }

    private boolean canHarvest(int[] bloomDay, int m, int k, int harvestDay){
        var adjacent = 0;
        for(var bd : bloomDay){
            if(bd <= harvestDay) adjacent++;
            else adjacent = 0;  // reset count

            if(adjacent == k){
                adjacent = 0;
                m--;
            }
        }
        return m <= 0;
    }
}