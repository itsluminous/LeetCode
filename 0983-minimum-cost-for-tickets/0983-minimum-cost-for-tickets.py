class Solution:
    def mincostTickets(self, days: List[int], costs: List[int]) -> int:
        # dp array to track min cost to travel each day
        lastDay = days[len(days) - 1]
        dp = [0] * (lastDay+1)

        # boolean array to easily check if a day is travel day
        travelDay = [False] * (lastDay+1)
        for day in days: travelDay[day] = True

        # find min cost to travel each day till last day
        for i in range(1, lastDay+1):
            if not travelDay[i]:
                dp[i] = dp[i-1]    # not buying any ticket
                continue

            # pick the ticket which costs least
            dp[i] = costs[0] + dp[i-1] # daily ticket
            dp[i] = min(dp[i], costs[1] + dp[max(i-7, 0)])   # weekly ticket
            dp[i] = min(dp[i], costs[2] + dp[max(i-30, 0)])   # weekly ticket
        
        return dp[lastDay]