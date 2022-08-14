public class Solution {
    public int EdgeScore(int[] edges) {
        var n = edges.Length;
        var scores = new long[n];
        
        for(var i=0; i<n; i++) scores[edges[i]] += i;
        var max = scores.Max();
        return scores.ToList().IndexOf(max);
    }
}