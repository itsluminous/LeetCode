public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        var pyramid = new double[101,101];
        pyramid[0, 0] = (double) poured;
        
        for(var r = 0; r <= query_row; r++){
            for(var c = 0; c <= r; c++){
                var overflow = (pyramid[r,c] - 1) / 2.0;
                if(overflow > 0){
                    pyramid[r+1, c] += overflow;
                    pyramid[r+1, c+1] += overflow;
                }
            }
        }
        
        return Math.Min(1, pyramid[query_row, query_glass]);
    }
}