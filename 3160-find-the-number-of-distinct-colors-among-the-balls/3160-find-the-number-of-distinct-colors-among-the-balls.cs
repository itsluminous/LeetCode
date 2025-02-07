public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        var ballColor = new Dictionary<int, int>(); // track color of each ball
        var colors = new Dictionary<int, int>();    // count how many balls have a color
        
        var n = queries.Length;
        var ans = new int[n];

        for(var i=0; i<n; i++){
            int ball = queries[i][0], color = queries[i][1];

            // if ball already has a color, remove it
            if(ballColor.ContainsKey(ball)){
                var c = ballColor[ball];
                colors[c]--;
                if(colors[c] == 0)
                    colors.Remove(c);
            }

            // set new color
            ballColor[ball] = color;
            if(colors.ContainsKey(color)) colors[color]++;
            else colors[color] = 1;

            // count the distinct colors
            ans[i] = colors.Count;
        }

        return ans;
    }
}