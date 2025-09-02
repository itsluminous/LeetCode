// O(n^2)
class Solution {
    public int numberOfPairs(int[][] points) {
        var SMALLEST = -51; // smallest possible y
        int n = points.length, ans = 0;
        Arrays.sort(points, (p1, p2) -> {
            if (p1[0] == p2[0]) return p2[1] - p1[1];   // y descending
            else return p1[0] - p2[0];                  // x ascending
        });

        for(var i=0; i<n; i++){
            int x1 = points[i][0], y1 = points[i][1];
            var ymax = SMALLEST;
            for(var j=i+1; j<n; j++){
                int x2 = points[j][0], y2 = points[j][1];

                if(y2 > y1) continue;   // point 2 is above point 1. We want reverse
                // we cannot go lower than already visited y, else it will include more points in rectangle
                if(y2 > ymax){
                    ans++;
                    ymax = y2;
                }
            }
        }

        return ans;
    }
}