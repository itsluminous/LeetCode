class Solution {
    public int[] missingRolls(int[] rolls, int mean, int n) {
        var expectedTotal = mean * (rolls.length + n);
        var currTotal = Arrays.stream(rolls).sum();
        var remaining = expectedTotal - currTotal;

        if(remaining < n || remaining > n * 6) return new int[0];

        int newMean = remaining / n, pending = remaining % n;
        var ans = new int[n];
        Arrays.fill(ans, newMean);
        for(var i=0; i<pending; i++) ans[i]++;
        
        return ans;
    }
}