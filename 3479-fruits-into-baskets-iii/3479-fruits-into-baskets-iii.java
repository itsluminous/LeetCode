// square root decomposition = O(n × sqrt(n)​)
// split array into segments of size sqrt(n) and then look for match in segment first, then look at each basket in segment
class Solution {
    public int numOfUnplacedFruits(int[] fruits, int[] baskets) {
        int n = baskets.length, match = 0;
        var m = (int) Math.sqrt(n);
        var segLen = (n + m - 1) / m;   // length of each segment
        var segMax = new int[segLen];
        Arrays.fill(segMax, 0);

        // update max value in each segment
        for(var i=0; i<n; i++)
            segMax[i/m] = Math.max(segMax[i/m], baskets[i]);
        
        // find out right basket for each fruit
        for(var fruit : fruits){
            var s = 0;  // matching segment
            for(; s < segLen; s++){
                if(segMax[s] < fruit) continue;

                // find new max for segment
                segMax[s] = 0;
                var found = false;  // found a match
                for(var i=s*m; i<n && i<(s+1)*m; i++){
                    if(!found && baskets[i] >= fruit) {
                        baskets[i] = 0; // use only one basket
                        found = true;
                    }
                    segMax[s] = Math.max(segMax[s], baskets[i]);
                }
                if(found) match++;
                break;
            }
        }

        return n - match;
    }
}