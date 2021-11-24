public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        // if(firstList.Length == 0 || secondList.Length == 0) return new int[][2];
        
        var intersections = new List<int[]>();
        int i=0, j=0;
        
        while(i<firstList.Length && j<secondList.Length){
            int[] f = firstList[i], s = secondList[j];
            
            // if the two intervals are disjoint
            if(f[0] > s[1]){
                j++;
            }
            else if(s[0] > f[1]){
                i++;
            }
            else{
                var curr = new []{-1,-1};
                // start of interval will be max of start of two sets
                curr[0] = Math.Max(f[0], s[0]);     
                
                // now update the end time for that interval
                if(f[1] == s[1]){
                    curr[1] = f[1];
                    i++; j++;
                }
                else if(f[1] < s[1]){
                    curr[1] = f[1];
                    i++;
                }
                else{
                    curr[1] = s[1];
                    j++;
                }
                
                // add the current interval to result
                intersections.Add(curr);
            }
        }
        
        return intersections.ToArray();
    }
}