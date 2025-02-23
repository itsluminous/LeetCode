public class Solution {
    public int MaxDistance(int side, int[][] points, int k) {
        // imagine opening up entire square into a flat line
        List<long> posList = new List<long>();
        foreach(var p in points)
            posList.Add(NormalizePos(side, p));
        
        long[] pos = posList.ToArray();
        Array.Sort(pos);

        // binary search to find max of min manhattan distance we can get
        long perimeter = 4L * side;
        long lo = 0, hi = perimeter, ans = 0;
        
        while(lo <= hi) {
            long mid = lo + (hi - lo) / 2;
            if(CanDo(pos, mid, k, perimeter)) {
                ans = mid;
                lo = mid + 1;
            }
            else
                hi = mid - 1;
        }
        
        return (int)ans;
    }
    
    private bool CanDo(long[] pos, long dist, int k, long perimeter) {
        var n = pos.Length;
        if(k == 1) return true;

        // try to fetch k points starting from each index
        for(var i = 0; i < n; i++) {
            int curr = i, count = 1;

            // check if we can get k points with distance >= dist
            for(var j = 1; j < k; j++) {
                long target = pos[curr] + dist;
                int idx = Array.BinarySearch(pos, target);
                if (idx < 0) idx = ~idx;
                if (idx >= n) break;
                curr = idx;
                count++;
            }

            // we represent pos as single line, but it wraps around as a circle
            // so need to ensure that distance between last point picked and first point is "dist"
            if (count >= k) {
                long span = pos[curr] - pos[i];
                if(span <= perimeter - dist) return true;
            }
        }
        return false;
    }
    
    private long NormalizePos(int side, int[] p) {
        int x = p[0], y = p[1];
        if(y == 0) return x;                            // bottom edge
        if(x == side) return (long)side + y;            // right edge
        if(y == side) return 2L * side + (side - x);    // top edge
        return 3L * side + (side - y);                  // left edge
    }
}
