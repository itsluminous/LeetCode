public class Solution {
    public int DigArtifacts(int n, int[][] artifacts, int[][] dig) {
        var di = new bool[n,n];
        var extract = 0;
        
        // in nxn matrix, mark all positions which are digged
        foreach(var d in dig)
            di[d[0], d[1]] = true;
        
        // for each artifact, check if required positions are digged or not
        foreach(var a in artifacts){
            var found = true;
            for(int i=a[0]; i<=a[2]; i++){
                for(int j=a[1]; j<=a[3]; j++){
                    if(!di[i,j]){
                        found = false;
                        break;
                    }
                }
                if(!found) break;
            }
            if(found) extract++;
        }
        
        return extract;
    }
}