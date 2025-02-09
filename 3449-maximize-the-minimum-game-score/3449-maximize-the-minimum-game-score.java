class Solution {
    public long maxScore(int[] points, int m) {
        var n = points.length;
        if (m < n) return 0;  // at least one index will be untouched, hence 0

        long lo = 0, hi = (long)(1e6 * m / n) + 1;
        while (lo < hi) {
            long mi = lo + (hi - lo + 1) / 2;
            if(possible(points, m, mi))
                lo = mi;
            else
                hi = mi - 1;
        }

        return lo;
    }

    // function to check if it's possible to achieve a certain bound
    private boolean possible(int[] points, int m, long bound) {
        var n = points.length;
        
        // calculate the required moves for each point
        long[] req = new long[n];
        for (int i = 0; i < n; i++) {
            req[i] = (bound + points[i] - 1) / points[i];
        }

        long moves = 0;
        for (var i = 0; i < n; i++) {
            var required = req[i];
            if (required > 0) {
                moves += 2 * required - 1;  // double moves since we have to do to-and-fro
                if (i < n - 1)
                    req[i + 1] = Math.max(0, req[i + 1] - (req[i] - 1));  // update the next point's required moves
            }
            else if (i < n - 1)
                moves += 1;  // for points with no extra moves, add 1 if it's not the last point
        }

        return moves <= m;
    }
}