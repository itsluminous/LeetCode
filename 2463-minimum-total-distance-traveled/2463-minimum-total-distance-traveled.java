class Solution {
    long inf = (long) 1e12;
    long[][] dp;

    public long minimumTotalDistance(List<Integer> robot, int[][] factory) {
        Collections.sort(robot);
        
        Arrays.sort(factory, (f1, f2) -> f1[0] - f2[0]);
        // flatten the factory
        var factories = new ArrayList<Integer>();
        for(var f : factory)
            for(var i=0; i < f[1]; i++)
                factories.add(f[0]);
        
        dp = new long[robot.size()][factories.size()];
        for(var i=0; i<robot.size(); i++)
            for(var j=0; j<factories.size(); j++)
                dp[i][j] = -1;

        return minimumTotalDistance(robot, factories, 0, 0);
    }

    private long minimumTotalDistance(List<Integer> robot, List<Integer> factories, int r, int f) {
        if(r == robot.size()) return 0;  // all robots fixed, no extra cost now
        if(f == factories.size()) return inf;  // all factories exhausted, this is a bad solution
        if(dp[r][f] != -1) return dp[r][f];

        // don't fix in curr factory
        var notFix = minimumTotalDistance(robot, factories, r, f+1);

        // fix in curr factory
        var fix = Math.abs(factories.get(f) - robot.get(r)) + minimumTotalDistance(robot, factories, r+1, f+1);
        
        dp[r][f] = Math.min(fix, notFix);
        return dp[r][f];
    }
    
}