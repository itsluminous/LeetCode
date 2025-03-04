public class Solution {
    public bool CheckPowersOfThree(int n) {
        // try to represent n in base 3 system
        // eg: 91 = 10101 (3^4 * 1  +  3^3 * 0  + 3^2 * 1  + 3^1 * 0  + 3^0 * 1)
        
        // in base 3 system, we can have either 0 or 1
        // if n % 3 == 2 at any point, it means we need to use same power twice
        while(n > 0){
            if(n % 3 == 2) return false;
            n /= 3;
        }
        return true;    // n is now 0
    }
}

// Accepted
public class SolutionGreedy {
    public bool CheckPowersOfThree(int n) {
        // 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049, 177147, 531441, 1594323, 4782969
        var len = 15;   // 3^15 exceeds 1e7
        var pow = new int[len];  
        for(var i=0; i<len; i++)
            pow[i] = (int)Math.Pow(3, i);
        
        var idx = len - 1;
        while(n > 0){
            // subtract curr power if we can
            if(n >= pow[idx]) n -= pow[idx];
            
            // same power cannot be used twice
            // and it is guaranteed that sum of all smaller powers will always be less than curr power
            if(n >= pow[idx]) return false;

            idx--;
        }

        return true;    // n is now 0
    }
}

// OOM
public class SolutionOOM {
    bool?[,] dp;

    public bool CheckPowersOfThree(int n) {
        // 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049, 177147, 531441, 1594323, 4782969
        var len = 15;   // 3^15 exceeds 1e7
        var pow = new int[len];  
        for(var i=0; i<len; i++)
            pow[i] = (int)Math.Pow(3, i);
        
        dp = new bool?[n+1, len];
        return IsSum(n, pow, len-1);
    }

    private bool IsSum(int n, int[] pow, int idx){
        if(n == 0) return true; // prev loop solved it
        if(idx < 0 || n < 0) return false;
        if(n < pow[idx]) return IsSum(n, pow, idx-1);
        if(dp[n, idx] != null) return dp[n, idx].Value;
        
        dp[n, idx] = IsSum(n - pow[idx], pow, idx - 1) || IsSum(n, pow, idx-1);
        return dp[n, idx].Value;
    }
}