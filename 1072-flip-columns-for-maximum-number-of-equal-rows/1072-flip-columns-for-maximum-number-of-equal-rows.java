class Solution {
    public int maxEqualRowsAfterFlips(int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        var freq = new HashMap<String, Integer>();

        // count how many rows have same or exact opposite bits
        // we check opposites because after flipping, if curr row is 1111, then the opposite will be 0000
        for(var i=0; i<m; i++){
            StringBuilder bits = new StringBuilder(), flip = new StringBuilder();
            for(var j=0; j<n; j++){
                bits.append(matrix[i][j]);
                flip.append(1 - matrix[i][j]);
            }

            freq.put(bits.toString(), freq.getOrDefault(bits.toString(), 0) + 1);
            freq.put(flip.toString(), freq.getOrDefault(flip.toString(), 0) + 1);
        }

        var ans = 0;
        for(var count : freq.values())
            ans = Math.max(ans, count);

        return ans;
    }
}

// Accepted - without using hashmap
class Solution1 {
    public int maxEqualRowsAfterFlips(int[][] matrix) {
        int m = matrix.length, n = matrix[0].length, ans = 0;

        // count how many rows have same or exact opposite bits
        // we check opposites because after flipping, if curr row is 1111, then the opposite will be 0000
        for(var i=0; i<m; i++){
            // flipped value for curr row
            var flip = new int[n];
            for(var j=0; j<n; j++)  flip[j] = 1 - matrix[i][j];

            var curr = 1;
            for(var j=i+1; j<m; j++)
                if(Arrays.equals(matrix[j], matrix[i]) || Arrays.equals(matrix[j], flip))
                    curr++;
            
            ans = Math.max(ans, curr);
        }

        return ans;
    }
}