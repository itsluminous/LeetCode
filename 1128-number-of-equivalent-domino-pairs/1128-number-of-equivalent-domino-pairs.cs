public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        var ans = 0;
        var freq = new int[100];    // 1 <= dominoes[i][j] <= 9, so 2 dominoes can be represented in 2 digits

        foreach(var dom in dominoes){
            Array.Sort(dom);
            var key = 10 * dom[0] + dom[1];
            ans += freq[key];
            freq[key]++;
        }

        return ans;
    }
}