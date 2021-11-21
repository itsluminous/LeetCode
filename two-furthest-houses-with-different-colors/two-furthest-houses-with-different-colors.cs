// Intuition - we maintain index of first two different colours. max dist has to be dist between one of these two
public class Solution {
    public int MaxDistance(int[] colors) {
        int c1Idx=0, c2Idx=-1, maxDist=0;
        for(var i=1; i<colors.Length; i++){
            if(colors[i] != colors[c1Idx]){
                maxDist = i-c1Idx;
                // if this is first time we encounter a new colour, record it
                if(c2Idx == -1) c2Idx = i;
            }
            else if(c2Idx != -1 && colors[i] != colors[c2Idx]){
                maxDist = Math.Max(maxDist, i-c2Idx);
            }
        }
        return maxDist;
    }
}