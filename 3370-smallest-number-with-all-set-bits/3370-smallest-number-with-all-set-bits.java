class Solution {
    public int smallestNumber(int n) {
        var ans = 1;
        while(ans < n)
            ans = 1 + ans*2;
        return ans;
    }
}