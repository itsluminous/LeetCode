// all the set bits in n represent min powers of two
public class Solution {
    public int[] ProductQueries(int n, int[][] queries) {
        var MOD = 1_000_000_007;
        var powers = new List<int>();
        for(var i=0; i<30 && n > 0; i++, n >>= 1)
            if((n & 1) == 1) powers.Add((int)Math.Pow(2, i));
        
        var ans = new int[queries.Length];
        var idx = 0;
        foreach(var query in queries){
            long prod = 1;
            for(var i = query[0]; i<= query[1]; i++)
                prod = (prod * powers[i]) % MOD;
            ans[idx++] = (int)prod;
        }

        return ans;
    }
}