class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var freq = new Dictionary<string, int>();

        // count how many rows have same or exact opposite bits
        // we check opposites because after flipping, if curr row is 1111, then the opposite will be 0000
        for(var i=0; i<m; i++){
            StringBuilder bits = new(), flip = new();
            for(var j=0; j<n; j++){
                bits.Append(matrix[i][j]);
                flip.Append(1 - matrix[i][j]);
            }

            if(freq.ContainsKey(bits.ToString())) freq[bits.ToString()]++;
            else freq[bits.ToString()] = 1;

            if(freq.ContainsKey(flip.ToString())) freq[flip.ToString()]++;
            else freq[flip.ToString()] = 1;
        }

        var ans = 0;
        foreach(var count in freq.Values)
            ans = Math.Max(ans, count);

        return ans;
    }
}

// Accepted - without using dictionary
public class Solution1 {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length, ans = 0;

        // count how many rows have same or exact opposite bits
        // we check opposites because after flipping, if curr row is 1111, then the opposite will be 0000
        for(var i=0; i<m; i++){
            // flipped value for curr row
            var flip = new int[n];
            for(var j=0; j<n; j++)  flip[j] = 1 - matrix[i][j];

            var curr = 1;
            for(var j=i+1; j<m; j++)
                if(matrix[j].SequenceEqual(matrix[i]) || matrix[j].SequenceEqual(flip))
                    curr++;
            
            ans = Math.Max(ans, curr);
        }

        return ans;
    }
}