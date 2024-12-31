public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        // dp array to track min cost to travel each day
        var lastDay = days[days.Length - 1];
        var dp = new int[lastDay+1];

        // boolean array to easily check if a day is travel day
        var travelDay = new bool[lastDay+1];
        foreach(var day in days) travelDay[day] = true;

        // find min cost to travel each day till last day
        for(var i=1; i<=lastDay; i++){
            if(!travelDay[i]){
                dp[i] = dp[i-1];    // not buying any ticket
                continue;
            }

            // pick the ticket which costs least
            dp[i] = costs[0] + dp[i-1]; // daily ticket
            dp[i] = Math.Min(dp[i], costs[1] + dp[Math.Max(i-7, 0)]);   // weekly ticket
            dp[i] = Math.Min(dp[i], costs[2] + dp[Math.Max(i-30, 0)]);   // weekly ticket
        }
        
        return dp[lastDay];
    }
}