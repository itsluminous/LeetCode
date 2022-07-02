public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        var MOD = 1_000_000_007;
        int hlen = horizontalCuts.Length, vlen = verticalCuts.Length;
        
        // find width of biggest slice
        Array.Sort(horizontalCuts);
        var maxW = Math.Max(horizontalCuts[0], h - horizontalCuts[hlen-1]); // width of edges
        for(var i=1; i<hlen; i++)
            maxW = Math.Max(maxW, horizontalCuts[i] - horizontalCuts[i-1]);
        
        // find height of biggest slice
        Array.Sort(verticalCuts);
        var maxH = Math.Max(verticalCuts[0], w - verticalCuts[vlen-1]);     // height of edges
        for(var i=1; i<vlen; i++)
            maxH = Math.Max(maxH, verticalCuts[i] - verticalCuts[i-1]);
        
        var area = (long) maxH * maxW % MOD;
        return (int) area;
    }
}