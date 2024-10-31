// 2d matrix
public class Solution {
    long inf = (long) 1e12;
    long[,] dp;

    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        var robots = robot.ToList();
        robots.Sort();
        
        Array.Sort(factory, (f1, f2) => f1[0] - f2[0]);
        // flatten the factory
        var factories = new List<int>();
        foreach(var f in factory)
            for(var i=0; i < f[1]; i++)
                factories.Add(f[0]);
        
        dp = new long[robots.Count, factories.Count];
        for(var i=0; i<robots.Count; i++)
            for(var j=0; j<factories.Count; j++)
                dp[i,j] = -1;

        return MinimumTotalDistance(robots, factories, 0, 0);
    }

    private long MinimumTotalDistance(IList<int> robot, IList<int> factories, int r, int f) {
        if(r == robot.Count) return 0;  // all robots fixed, no extra cost now
        if(f == factories.Count) return inf;  // all factories exhausted, this is a bad solution
        if(dp[r,f] != -1) return dp[r,f];

        // don't fix in curr factory
        var notFix = MinimumTotalDistance(robot, factories, r, f+1);

        // fix in curr factory
        var fix = Math.Abs(factories[f] - robot[r]) + MinimumTotalDistance(robot, factories, r+1, f+1);
        
        dp[r,f] = Math.Min(fix, notFix);
        return dp[r,f];
    }
}

// Accepted
public class Solution3dMatrix {
    long inf = (long) 1e12;
    long[,,] dp;

    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        var robots = robot.ToList();
        robots.Sort();
        Array.Sort(factory, (f1, f2) => f1[0] - f2[0]);
        
        dp = new long[robots.Count, factory.Length, 101];    // because 1 <= robot.length <= 100
        for(var i=0; i<robots.Count; i++)
            for(var j=0; j<factory.Length; j++)
                for(var k=0; k<101; k++)
                    dp[i,j,k] = -1;

        return MinimumTotalDistance(robots, factory, 0, 0, 0);
    }

    private long MinimumTotalDistance(IList<int> robot, int[][] factory, int r, int f, int done) {
        if(r == robot.Count) return 0;  // all robots fixed, no extra cost now
        if(f == factory.Length) return inf;  // all factories exhausted, this is a bad solution
        if(dp[r,f,done] != -1) return dp[r,f,done];

        // don't fix in curr factory
        var notFix = MinimumTotalDistance(robot, factory, r, f+1, 0);

        // fix in curr factory
        var fix = inf;
        if(factory[f][1] > done)
            fix = Math.Abs(factory[f][0] - robot[r]) + MinimumTotalDistance(robot, factory, r+1, f, done+1);
        
        dp[r,f,done] = Math.Min(fix, notFix);
        return dp[r,f,done];
    }
}