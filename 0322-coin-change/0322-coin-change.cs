// BFS
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0) return 0;

        var seen = new HashSet<int>();
        var queue = new Queue<int>();
        foreach(var coin in coins){
            if(coin == amount) return 1;
            if(coin < amount){
                seen.Add(coin);
                queue.Enqueue(coin);
            }   
        }

        for(var count=2; queue.Count > 0; count++){
            for(var i=queue.Count; i>0; i--){
                var prev = queue.Dequeue();
                foreach(var coin in coins){
                    var curr = prev + coin;
                    if(curr == amount) return count;
                    if(curr < amount && seen.Add(curr))
                        queue.Enqueue(curr);
                }
            }
        }

        return -1;
    }
}

// Iterative
public class Solution3 {
    public int CoinChange(int[] coins, int amount) {
        var dp = new int[amount+1];   // +1 because we include 0 amount also

        // fill up dp for case when amount is sum
        for (var sum = 1; sum <= amount; sum++)
        {
            var min = int.MaxValue;   // local minimum
            foreach(var coin in coins){
                // if including current coin does not exceed sum & there is a way to reach sum-coin value
                if(sum >= coin && dp[sum-coin] != -1)
                    min = Math.Min(min, dp[sum-coin]); 
            }
            // dp[sum] will be min of when we include coin and when we don't include
            dp[sum] = min == int.MaxValue ? -1 : 1+min;  // 1+min because we include one coin
        }

        return dp[amount];
    }
}

// Accepted - recursive
public class Solution2 {
    public int CoinChange(int[] coins, int amount) {
        return CoinChange(coins, amount, new int[amount+1]);
    }
    
    private int CoinChange(int[] coins, int amount, int[] dp) {
        if(amount < 0) return -1;               // cannot make this amount
        if(amount == 0) return 0;               // found a combination of coins
        if(dp[amount] != 0) return dp[amount];  // if count for this amount was already evaluated
        
        // find min count of coins to get this amount
        var min = int.MaxValue;
        foreach(var coin in coins){
            var count = CoinChange(coins, amount-coin, dp);
            if(count >= 0 && count < min)
                min = 1 + count;
        }
        
        // save value in dp
        dp[amount] = min == int.MaxValue ? -1 : min;
        return dp[amount];
    }
}

// Accepted
public class Solution1 {
    int min = int.MaxValue;
    int[] dp; // Using dictionary for dp causes TLE
    
    public int CoinChange(int[] coins, int amount) {
        dp = new int[amount+1];
        return CoinChange(coins, amount, 0);
    }
    
    public int CoinChange(int[] coins, int amount, int total) {
        // if current count is greater than min or sum exceeds amount
        if(total >= min || amount < 0) return -1;
        
        // if found match
        if(amount == 0){    
            min = total;
            return min;
        }
        
        // if dp has it and we reached this amount in less steps, then don't proceed
        if(dp[amount] != 0 && dp[amount] <= total) return -1;
        dp[amount] = total;
        
        // try other cases
        foreach(var c in coins)
            CoinChange(coins, amount-c, total+1);
        
        return min == int.MaxValue ? -1 : min;
    }
}