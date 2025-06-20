public class Solution {
    public int MaxDistance(string s, int k) {
        var maxDist = 0;
        var directionMap = new Dictionary<char, int[]> {
            {'N', [0, 1]},
            {'S', [0, -1]},
            {'E', [1, 0]},
            {'W', [-1, 0]}
        };

        int x = 0, y = 0;  // track cumulative x and y movement
        for(var i = 0; i < s.Length; i++) {
            var change = directionMap[s[i]];
            x += change[0];
            y += change[1];

            // calculate manhattan distance without changing anything
            var currDist = Math.Abs(x) + Math.Abs(y);

            // if i <= k then all dirs can be pointed to one diagonal, so maxDist = i+1
            // if i > k, then we can change k directions only. 
            // Each change will have double impact, because it removes one wrong dir and adds one right dir
            currDist = Math.Min(i + 1, currDist + 2 * k);
            maxDist = Math.Max(maxDist, currDist);
        }

        return maxDist;
    }
}
