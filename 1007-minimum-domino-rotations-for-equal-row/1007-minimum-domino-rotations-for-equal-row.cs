public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        var min = int.MaxValue;
        // for each number in dice 1 tp 6
        for(var val=1; val<=6; val++){
            min = Math.Min(min, GetRotations(tops, bottoms, val));  // see if we can make top row
            min = Math.Min(min, GetRotations(bottoms, tops, val));  // see if we can make bottom row
        }
        
        if(min == int.MaxValue) return -1;
        return min;
    }
    
    private int GetRotations(int[] top, int[] bot, int val){
        int n = top.Length, res = 0;
        for(var i=0; i<n; i++){
            if(top[i] == val) continue;
            if(bot[i] != val) return int.MaxValue;
            res++;
        }
        
        return res;
    }
}