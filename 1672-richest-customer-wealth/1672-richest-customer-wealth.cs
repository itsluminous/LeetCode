public class Solution {
    public int MaximumWealth(int[][] accounts) {
        var max = 0;
        foreach(var account in accounts){
            var curr = 0;
            foreach(var money in account) curr += money;
            max = Math.Max(max, curr);
        }
        
        return max;
    }
}