class Solution {
    public int countTrapezoids(int[][] points) {
        var MOD = 1_000_000_007;
        var yFreq = new HashMap<Integer, Integer>();    // how many points have same y coordinate
        long ans = 0, sum = 0;

        for(var point : points) yFreq.put(point[1], yFreq.getOrDefault(point[1], 0) + 1);
        for(var freq : yFreq.values()){
            long edge = ((long) freq * (freq - 1)) / 2;
            ans = (ans + edge * sum) % MOD;
            sum = (sum + edge) % MOD;
        }

        return (int)ans;
    }
}