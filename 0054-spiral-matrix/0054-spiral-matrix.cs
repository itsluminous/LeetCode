public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var dir = new int[][]{[0, 1], [1, 0], [0, -1], [-1, 0]};
        int m = matrix.Length, n = matrix[0].Length;
        
        // range tells max we can go in x & y direction.
        // m-1 because would already have covered first element from col while traversing the row
        var range = new[]{n, m-1};  
        
        var ans = new List<int>();
        int r=0, c=-1, d=0;     // c = -1 because before reading val from matrix, we first add one to it

        // run loop till any range (x or y) becomes zero. So we cannot go further
        while(range[d%2] != 0){
            for(var i=0; i<range[d%2]; i++){
                r += dir[d][0];
                c += dir[d][1];
                ans.Add(matrix[r][c]);
                // Console.WriteLine($"{i}/{range[d%2]} :: {r}:{c}, d={d}");
            }
            // next time we traverse in this axis, we will have one less number
            range[d%2]--;
            d = (d+1)%4;
        }

        return ans;
    }
}