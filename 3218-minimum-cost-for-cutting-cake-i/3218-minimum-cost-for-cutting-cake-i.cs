public class Solution {
    public int MinimumCost(int m, int n, int[] hCut, int[] vCut) {
        Array.Sort(hCut);
        Array.Sort(vCut);

        int hidx = hCut.Length-1, vidx = vCut.Length-1;
        int hCount=1, vCount=1;
        int cost = 0;
        
        while(hidx >= 0 && vidx >= 0) {
            if(hCut[hidx] >= vCut[vidx]) {
                cost += (hCut[hidx] * vCount);
                hCount++;
                hidx--;
            }
            else{
                cost += (vCut[vidx] * hCount);
                vCount++;
                vidx--;
            }
        }
        
        while (hidx >= 0)
            cost += hCut[hidx--] * vCount;
        
        while (vidx >= 0)
            cost += vCut[vidx--] * hCount;
        
        return cost;
    }
}