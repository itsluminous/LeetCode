public class Solution {
    public int MaximumWealth(int[][] accounts) {
        var max = 0;
        for(var i=0; i<accounts.Length; i++){
            var curr = 0;
            for(var j=0; j<accounts[0].Length; j++)
                curr += accounts[i][j];
            max = Math.Max(max, curr);
        }
        
        return max;
    }
}