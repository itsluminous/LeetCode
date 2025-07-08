class Solution {
    int[][] dp;

    public int maxValue(int[][] events, int k) {
        Arrays.sort(events, (e1, e2) -> e1[0] - e2[0]);
        
        dp = new int[events.length][k+1]; // max value possible when we reach index i with k selections left
        for(var row : dp) Arrays.fill(row, -1);
        return dfs(events, k, 0);
    }

    private int dfs(int[][] events, int k, int idx){
        if(k == 0 || idx == events.length) return 0;
        if(dp[idx][k] != -1) return dp[idx][k];
        
        // find out index of first event starting after curr event ends
        var nextIdx = binarySearch(events, events[idx][1]);

        // we can skip curr event, or count it and then explore other events after it
        dp[idx][k] = Math.max(dfs(events, k, idx+1), events[idx][2] + dfs(events, k-1, nextIdx));
        return dp[idx][k];
    }

    private int binarySearch(int[][] events, int day){
        int l = 0, r = events.length;
        while(l < r){
            var mid = l + (r - l) / 2;
            if(events[mid][0] <= day) l = mid + 1;
            else r = mid;
        }
        return l;
    }
}