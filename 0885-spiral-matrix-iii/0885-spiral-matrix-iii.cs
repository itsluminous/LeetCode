public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        var dirs = new int[,]{{0,1}, {1,0}, {0,-1}, {-1,0}};
        var path = new int[rows * cols][];

        // step should be 1,1,2,2,3,3,4,4,....
        for(int step = 1, dirIdx = 0, pathIdx = 0; pathIdx < rows * cols; step++ ){
            // for every step we traverse two directions.
            for(var i=0; i<2; i++, dirIdx = (dirIdx + 1) % 4){
                for(var j=0; j<step; j++){
                    // if curr coordinates is a valid point, then add it to path
                    if(rStart >= 0 && cStart >= 0 && rStart < rows && cStart < cols)
                        path[pathIdx++] = [rStart, cStart];

                    // move to next pos
                    rStart += dirs[dirIdx,0];
                    cStart += dirs[dirIdx,1];
                }
            }
        }

        return path;
    }
}