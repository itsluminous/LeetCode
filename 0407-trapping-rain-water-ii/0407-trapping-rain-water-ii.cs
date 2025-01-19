// explaination : https://leetcode.com/problems/trapping-rain-water-ii/solutions/1138028/python3-visualization-bfs-solution-with-explanation
public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        int m = heightMap.Length, n = heightMap[0].Length;
        var dirs = new int[,]{{ 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }};
        
        // pq will always give smallest height cell, and then we check if its neighbours can trap water
        // we add all boundary cells to pq because they cannot trap water
        var pq = PQwithBoundaryCells(heightMap);

        // look at neighbours of all cells one by one
        int trapped = 0, level = 0;
        while(pq.Count > 0){
            var (height, x, y) = pq.Dequeue();
            level = Math.Max(level, height);

            // check all neighbours
            for(var d=0; d<4; d++){
                int xx = x + dirs[d,0], yy = y + dirs[d,1];
                if(xx == -1 || yy == -1 || xx == m || yy == n || heightMap[xx][yy] == -1) continue;

                if(heightMap[xx][yy] < level) trapped += level - heightMap[xx][yy]; // can trap water
                pq.Enqueue((heightMap[xx][yy], xx, yy), heightMap[xx][yy]);
                heightMap[xx][yy] = -1;
            }
        }

        return trapped;
    }

    private PriorityQueue<(int, int, int), int> PQwithBoundaryCells(int[][] heightMap){
        int m = heightMap.Length, n = heightMap[0].Length;
        var pq = new PriorityQueue<(int, int, int), int>();

        for(var i=0; i<m; i++){
            pq.Enqueue((heightMap[i][0], i, 0), heightMap[i][0]);
            heightMap[i][0] = -1;
            pq.Enqueue((heightMap[i][n-1], i, n-1), heightMap[i][n-1]);
            heightMap[i][n-1] = -1;
        }
        for(var j=0; j<n; j++){
            pq.Enqueue((heightMap[0][j], 0, j), heightMap[0][j]);
            heightMap[0][j] = -1;
            pq.Enqueue((heightMap[m-1][j], m-1, j), heightMap[m-1][j]);
            heightMap[m-1][j] = -1;
        }

        return pq;
    }
}