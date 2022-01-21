public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length, total = 0, start = 0;
        
        // check if we have solution
        for(var i=0; i<n; i++)
            total += gas[i] - cost[i];
        
        // solution is not possible
        if(total < 0) return -1;
        
        // find a start point from where total is never negative
        total = 0;
        for(var i=0; i<n; i++){
            total += gas[i] - cost[i];
            if(total < 0){
                start = i+1;
                total = 0;
            }
        }
        
        return start;
    }
}