public class Solution {
    public int NumberOfWeakCharacters(int[][] properties) {
        int n = properties.Length, weak = 0;
        
        // 1. sort the array by attack. so any player at next idx will always have bigger attack
        var prop = properties.OrderBy(p => p[0]).ToArray();
        
        // 2. for each idx, find out max defence of right side players
        var defence = new int[n];
        defence[n-1] = -1;    // nothing greater than the last one
        int maxnow = -1, maxprev = -1;      // two variables to track max with same attack and greater attack
        for(var i=n-2; i>=0; i--){
            maxnow = Math.Max(prop[i+1][1], Math.Max(maxnow, maxprev));
            if(prop[i][0] == prop[i+1][0]){
                defence[i] = maxprev;
            }
            else{
                defence[i] = Math.Max(maxnow, maxprev);
                maxprev = maxnow;
                maxnow = -1;
            }
        }
        
        // 3. if there is any player on right side with better defence, then they have better or same attack.
        for(var i=0; i<n-1; i++)
            if(defence[i] > prop[i][1]) weak++;
        
        return weak;
    }
}