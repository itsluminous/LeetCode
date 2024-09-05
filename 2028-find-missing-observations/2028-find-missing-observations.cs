public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        var expectedTotal = mean * (rolls.Length + n);
        var currTotal = rolls.Sum();
        var remaining = expectedTotal - currTotal;

        if(remaining < n || remaining > n * 6) return new int[]{};

        int newMean = remaining / n, pending = remaining % n;
        var ans = new int[n];
        Array.Fill(ans, newMean);
        for(var i=0; i<pending; i++) ans[i]++;
        
        return ans;
    }
}