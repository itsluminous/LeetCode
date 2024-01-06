// Logic : sort based on start time, then find best possible combination using DFS

public class Solution {
    Dictionary<int,int> dp;

    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var n = startTime.Length;
        var jobs = new int[n][];
        for(var i=0; i<n; i++){
            jobs[i] = new []{startTime[i], endTime[i], profit[i]};
        }

        jobs = jobs.OrderBy(row => row[0]).ToArray();

        dp = new Dictionary<int,int>();
        return DFS(0, jobs);
    }

    private int DFS(int cur, int[][] jobs){
        if(cur == jobs.Length) return 0;
        if(dp.ContainsKey(cur)) return dp[cur];
        
        var next = FindNext(cur, jobs);
        var inclCurr = jobs[cur][2] + (next == -1 ? 0 : DFS(next, jobs));
        var exclCurr = DFS(cur+1, jobs);

        dp[cur] = Math.Max(inclCurr, exclCurr);
        return dp[cur];
    }

    private int FindNext(int cur, int[][] jobs){
        for(var next=cur+1; next < jobs.Length; next++){
            if(jobs[next][0] >= jobs[cur][1])
                return next;
        }
        return -1;
    }
}