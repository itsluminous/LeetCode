public class Solution {
    public int[] dailyTemperatures(int[] temperatures) {
        var n = temperatures.length;
        var wait = new int[n];
        wait[n-1] = 0;

        for(var i=n-2; i>=0; i--){
            var idx = i+1;
            while(idx < n){
                // found a temperatures greater than current
                if(temperatures[idx] > temperatures[i]){
                    wait[i] = idx-i;
                    break;
                }
                // case where bigger temperatures does not exist
                if(wait[idx] == 0){
                    idx = n;
                    break;
                }
                // find next bigger temperatures
                idx += wait[idx];
            }
            if(idx == n) wait[i] = 0;
        }

        return wait;
    }
}