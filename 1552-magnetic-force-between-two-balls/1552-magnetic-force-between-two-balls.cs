class Solution {
    public int MaxDistance(int[] position, int m) {
        var n = position.Length;
        Array.Sort(position);

        int minGap = 0, maxGap = (position[n-1] - position[0]), optimal = 0;
        while(minGap <= maxGap){
            var mid = minGap + (maxGap - minGap) / 2;
            if(Count(position, mid) >= m){   // if more balls are fitting, then we should give more gap
                optimal = mid;
                minGap = mid + 1;
            }
            else maxGap = mid - 1;
        }

        return optimal;
    }

    // Count number of balls that can be placed with given min gap
    private int Count(int[] position, int gap){
        int balls = 1, curr = position[0];
        for(var i=1; i < position.Length; i++){
            if(position[i] - curr >= gap){
                balls++;
                curr = position[i];
            }
        }
        return balls;
    }
}