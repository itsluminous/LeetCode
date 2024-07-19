class Solution {
    public List<Integer> luckyNumbers (int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        var rowMin = new int[m];
        var ans = new ArrayList<Integer>();

        for(var i=0; i<m; i++){
            var mn = matrix[i][0];
            for(var j=1; j<n; j++)
                mn = Math.min(mn, matrix[i][j]);
            rowMin[i] = mn;
        }

        for(var j=0; j<n; j++){
            var mx = matrix[0][j];
            for(var i=1; i<m; i++)
                mx = Math.max(mx, matrix[i][j]);
            
            for(var i=0; i<m; i++)
                if(rowMin[i] == mx){
                    ans.add(mx);
                    break;
                }
        }

        return ans;
    }
}