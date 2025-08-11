// all the set bits in n represent min powers of two
class Solution {
    public int[] productQueries(int n, int[][] queries) {
        var MOD = 1_000_000_007;
        var powers = new ArrayList<Integer>();
        for(var i=0; i<30 && n > 0; i++, n >>= 1)
            if((n & 1) == 1) powers.add((int)Math.pow(2, i));
        
        var ans = new int[queries.length];
        var idx = 0;
        for(var query : queries){
            long prod = 1;
            for(var i = query[0]; i<= query[1]; i++)
                prod = (prod * powers.get(i)) % MOD;
            ans[idx++] = (int)prod;
        }

        return ans;
    }
}