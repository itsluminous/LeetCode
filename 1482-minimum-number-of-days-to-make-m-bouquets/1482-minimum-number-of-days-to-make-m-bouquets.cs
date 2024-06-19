public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        var flowersNeeded = (long) m * k;
        var totalFlowers = bloomDay.Length;
        if(totalFlowers < flowersNeeded) return -1;

        // find the earliest we can start harvesting, and also last date
        int minDay = int.MaxValue, maxDay = 0;
        foreach(var bd in bloomDay){
            minDay = Math.Min(minDay, bd);
            maxDay = Math.Max(maxDay, bd);
        }
        if(flowersNeeded == totalFlowers) return maxDay;
        
        // now, try to find optimal day between minDay & maxDay
        while(minDay < maxDay){
            var mid = minDay + (maxDay - minDay) / 2;
            if(CanHarvest(bloomDay, m, k, mid))
                maxDay = mid;
            else
                minDay = mid + 1;
        }

        return minDay;
    }

    private bool CanHarvest(int[] bloomDay, int m, int k, int harvestDay){
        var adjacent = 0;
        foreach(var bd in bloomDay){
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