public class Solution {
    public long MaxRunTime(int n, int[] batteries) {
        Array.Sort(batteries);
        // find total capacity of all batteries. this will be used to calculate avg capacity for each computer
        long totalCapacity = 0;
        Array.ForEach(batteries, i => totalCapacity += i);
        
        int total = batteries.Length-1, used = 0;
        // for each battery, if its capacity is more than avg, we will never have to swap it.
        // so problem reduces to number of batteries left and computers left
        // of course, then avg of left batteries is also recomputed as remainingCapacity / remainingComputers
        while(batteries[total-used] > totalCapacity/(n-used)){
            totalCapacity -= batteries[total-used]; // remove this battery from total because it's assigned to a computer
            used++;                                 // increment used batteries & assigned computers count
        }
        
        // final result will be avg of remaining capacity of batteries, i.e. how much can each computer get
        return totalCapacity/(n-used);
    }
}