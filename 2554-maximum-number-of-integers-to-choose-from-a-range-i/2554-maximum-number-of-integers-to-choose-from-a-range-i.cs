public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        var bnd = new HashSet<int>(banned);
        var count = 0;
        for(var num=1; num<=n; num++){
            if(bnd.Contains(num)) continue;
            if(maxSum - num < 0) break;
            maxSum -= num;
            count++;
        }
        
        return count;
    }
}