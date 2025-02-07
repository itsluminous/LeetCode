class Solution {
    public int[] queryResults(int limit, int[][] queries) {
        var ballColor = new HashMap<Integer, Integer>(); // track color of each ball
        var colors = new HashMap<Integer, Integer>();    // count how many balls have a color
        
        var n = queries.length;
        var ans = new int[n];

        for(var i=0; i<n; i++){
            int ball = queries[i][0], color = queries[i][1];

            // if ball already has a color, remove it
            if(ballColor.containsKey(ball)){
                var c = ballColor.get(ball);
                colors.put(c, colors.get(c) - 1);
                if(colors.get(c) == 0)
                    colors.remove(c);
            }

            // set new color
            ballColor.put(ball, color);
            colors.put(color, 1 + colors.getOrDefault(color, 0));

            // count the distinct colors
            ans[i] = colors.size();
        }

        return ans;
    }
}