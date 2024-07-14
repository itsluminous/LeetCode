class Solution {
    public long minimumCost(int m, int n, int[] hCut, int[] vCut) {
        Arrays.sort(hCut);
        Arrays.sort(vCut);

        int hidx = hCut.length-1, vidx = vCut.length-1;
        int hCount=1, vCount=1;
        long cost = 0;
        
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