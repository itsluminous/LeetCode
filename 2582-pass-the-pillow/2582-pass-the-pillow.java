class Solution {
    public int passThePillow(int n, int time) {
        // remove full cycles
        var roundTrip = (n-1)*2;
        time %= roundTrip;

        // left to right
        if(time < n) return time+1;
        
        // right to left
        time -= n;
        return n - time - 1;
    }
}