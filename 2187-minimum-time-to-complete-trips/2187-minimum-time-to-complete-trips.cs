public class Solution {
    public long MinimumTime(int[] time, int totalTrips) {
        // constraints of the question it's given that the maximum limit of time[i] and totalTrips is 10^7 so we can take the upper bound for the HighestTime to be max(time[i])*totalTrips which will turn out to be 10^14.
        long low = 1, high = (long)(Math.Pow(10, 14));
        while(low < high){
            var mid = low + (high - low) / 2;
            if(GetTrips(time , mid) >= totalTrips)
                high = mid;
            else
                low = mid+1;
        }
        return low;
    }
    
    private long GetTrips(int[] time, long timeTaken){
        long trips = 0;
        foreach(var t in time)
            trips += (timeTaken/t);
            
        return trips;
    }
}