class Solution {
    public int numEquivDominoPairs(int[][] dominoes) {
        var ans = 0;
        var freq = new int[100];    // 1 <= dominoes[i][j] <= 9, so 2 dominoes can be represented in 2 digits

        for(var dom : dominoes){
            Arrays.sort(dom);
            var key = 10 * dom[0] + dom[1];
            ans += freq[key];
            freq[key]++;
        }

        return ans;
    }
}