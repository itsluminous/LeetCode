// it is important to note that matrix already created with all bars
// and you can only remove those bars which are present in hBars and vBars
public class Solution {
    public int maximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        // adding 1 here because removing 1 bar gives 2 cells, removing 2 gives 3 cells...
        var gap = 1 + Math.min(getMaxGap(hBars), getMaxGap(vBars));
        return gap * gap;
    }

    private int getMaxGap(int[] bars){
        Arrays.sort(bars);
        var ans = 1;    // min 1 cell will always be a hole
        var curr = 1;
        for(var i=1; i<bars.length; i++){
            // check if we are able to remove consecutive bars
            if(bars[i] == bars[i-1] + 1) curr++;
            else curr = 1;

            ans = Math.max(ans, curr);
        }
        return ans;
    }
}