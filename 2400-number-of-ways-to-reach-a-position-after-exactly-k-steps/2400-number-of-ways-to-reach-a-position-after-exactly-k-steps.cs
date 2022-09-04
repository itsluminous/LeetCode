public class Solution {
    int[,] dp = new int[1000,1001];     // to store number of ways to travel distance d in exactly k steps
    
    public int NumberOfWays(int startPos, int endPos, int k) {
        var dist = Math.Abs(endPos - startPos);
        if(dist % 2 != k % 2) return 0;     // if diff is even, steps should also be even, similarly for odd
        
        return dfs(dist, k);
    }
    
    private int dfs(int d, int k) {
        var mod = 1_000_000_007;
        
        if (d > k) return 0;
        if (d == k) return 1;
        
        if (dp[d,k] == 0){
            var movefar = dfs(d + 1, k - 1);
            var moveclose = dfs(d + (d != 0 ? -1 : 1), k - 1);   // if d == 0, we recurse for d + 1 instead of d - 1
            dp[d,k] = (1 + movefar + moveclose) % mod;
        }
        return dp[d,k] - 1;
    }
    
}

// BFS : Out of memory
public class Solution1 {
    public int NumberOfWays(int startPos, int endPos, int k) {
        var mod = 1_000_000_007;
        if(startPos > endPos) NumberOfWays(endPos, startPos, k);
        
        var diff = endPos - startPos;
        if(diff % 2 == 0 && k % 2 != 0) return 0;
        if(diff % 2 != 0 && k % 2 == 0) return 0;
        
        var q = new Queue<int>();
        q.Enqueue(startPos);
        
        var min = (startPos - endPos) / 2;
        var max = (endPos - startPos) / 2;
        while(k > 0){
            var len = q.Count;
            for(var i=0; i<len; i++){
                var num = q.Dequeue();
                if(num-1 >= min) q.Enqueue(num-1);
                if(num+1 <= max) q.Enqueue(num+1);
            }
            k--;
        }
        
        var paths = 0;
        while(q.Count > 0){
            var num = q.Dequeue();
            if(num == endPos) paths = (paths + 1) % mod;
        }
        
        return paths;
    }
}