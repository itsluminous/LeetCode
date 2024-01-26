public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);

        var gIdx = 0;
        foreach(var size in s){
            if(gIdx == g.Length) break;
            if(size >= g[gIdx]) gIdx++;
        }

        return gIdx;
    }
}