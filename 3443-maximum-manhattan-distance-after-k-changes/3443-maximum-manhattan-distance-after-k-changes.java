class Solution {
    public int maxDistance(String s, int k) {
        var maxDist = 0;
        var directionMap = Map.of('N', new int[]{0, 1}, 'S', new int[]{0, -1}, 'E', new int[]{1, 0}, 'W', new int[]{-1, 0});
        
        int x = 0, y = 0;   // track cumulative x and y movement
        for(var i=0; i<s.length(); i++){
            var change = directionMap.get(s.charAt(i));
            x += change[0];
            y += change[1];

            // calculate manhattan distance without changing anything
            var currDist = Math.abs(x) + Math.abs(y);

            // if i <= k then all dirs can be pointed to one diagonal, so maxDist = i+1
            // if i > k, then we can change k directions only. 
            // Each change will have double impact, because it removes one wrong dir and adds one right dir
            currDist = Math.min(i+1, currDist + 2 * k);
            maxDist = Math.max(maxDist, currDist);
        }
        
        return maxDist;
    }
}