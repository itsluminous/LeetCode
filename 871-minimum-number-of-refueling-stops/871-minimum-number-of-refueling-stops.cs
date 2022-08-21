public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        if(startFuel >= target) return 0;
        
        var ss = new SortedSet<(int, int)>();   // Set of (fuel, latest gas stn before refuelling)
        int n = stations.Length, idx = 0, stops = 0;
        
        // keep travelling till we have not reached destination
        while(startFuel < target){
            // keep going to next stn till we run out of fuel
            while(idx < n && stations[idx][0] <= startFuel){
                // add this to queue so that if this gives me max distance, then we will use it
                ss.Add((stations[idx][1], idx));
                idx++;
            }
            
            // if there is no other option left in queue then we cannot reach destination
            if(ss.Count == 0) return -1;
            
            // else, use the stop which helps us reach max distance
            startFuel += ss.Max.Item1;
            ss.Remove(ss.Max);
            stops++;
        }
        return stops;
    }
}