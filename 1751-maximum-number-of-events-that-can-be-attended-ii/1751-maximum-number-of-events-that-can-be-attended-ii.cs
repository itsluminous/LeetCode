public class Solution {
    int[][] dp;

    public int MaxValue(int[][] events, int k) {
        Array.Sort(events, (e1, e2) => e1[0] - e2[0]);
        
        dp = new int[events.Length][]; // max value possible when we reach index i with k selections left
        for(var i=0; i<events.Length; i++){
            dp[i] = new int[k+1];
            Array.Fill(dp[i], -1);
        }
        return DFS(events, k, 0);
    }

    private int DFS(int[][] events, int k, int idx){
        if(k == 0 || idx == events.Length) return 0;
        if(dp[idx][k] != -1) return dp[idx][k];
        
        // find out index of first event starting after curr event ends
        var nextIdx = BinarySearch(events, events[idx][1]);

        // we can skip curr event, or count it and then explore other events after it
        dp[idx][k] = Math.Max(DFS(events, k, idx+1), events[idx][2] + DFS(events, k-1, nextIdx));
        return dp[idx][k];
    }

    private int BinarySearch(int[][] events, int day){
        int l = 0, r = events.Length;
        while(l < r){
            var mid = l + (r - l) / 2;
            if(events[mid][0] <= day) l = mid + 1;
            else r = mid;
        }
        return l;
    }
}