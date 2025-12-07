class Solution {
    public int countOdds(int low, int high) {
        var ans = (high - low) / 2;
        if((low & 1) == 1 || (high & 1) == 1) ans++;
        return ans;
    }
}