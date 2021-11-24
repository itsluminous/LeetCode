public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        if(firstList.Length == 0 || secondList.Length == 0) return new int[0][];
        
        var result = new List<int[]>();
        int f=0, s=0, start, end;
        
        while(f<firstList.Length && s<secondList.Length){
            start = Math.Max(firstList[f][0], secondList[s][0]);
            end = Math.Min(firstList[f][1], secondList[s][1]);
            if(start <= end)
                result.Add(new []{start,end});
            
            //Now increment the one with lower endpoint
            if(firstList[f][1] < secondList[s][1])
                f++;
            else
                s++;
        }
        
        return result.ToArray();
    }
}

// Accepted
public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
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

// Accepted
public class Solution1 {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        if(firstList.Length == 0 || secondList.Length == 0)
            return new int[0][];
        
        var result = new List<int[]>();
        int f=0, s=0, start, end;
        
        while(f<firstList.Length && s<secondList.Length){
            // first list ends before second list starts
            if(firstList[f][1] < secondList[s][0]){
                f++;
                continue;
            }
            // second list ends before first list starts
            else if(secondList[s][1] < firstList[f][0]){
                s++;
                continue;
            }
            
            // use the starting point as the highest one of two starts
            if(firstList[f][0] < secondList[s][0]){
                start = secondList[s][0];
            }
            else
                start = firstList[f][0];
            
            // if first list ends after second list starts
            if(firstList[f][1] >= secondList[s][0]){
                // if first list ends after second list ends
                if(firstList[f][1] >= secondList[s][1])
                    end = secondList[s++][1];
                // if first list ends before second list ends
                else
                    end = firstList[f++][1];
                result.Add(new []{start,end});
            }
            else{
                f++;
            }
        }
        
        return result.ToArray();
    }
}
