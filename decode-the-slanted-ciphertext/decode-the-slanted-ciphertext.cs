// No extra space - https://leetcode.com/problems/decode-the-slanted-ciphertext/discuss/1576914/Jump-Columns-%2B-1
public class Solution {
    public string DecodeCiphertext(string encodedText, int rows) {
        int len = encodedText.Length, cols = len/rows, increment = cols+1;
        
        var sb = new StringBuilder();
        for(int i=0;i<cols; i++)
            for(int j=i; j<len; j+=increment)
                sb.Append(encodedText[j]);
        
        return sb.ToString().TrimEnd(); // remove trailing spaces
    }
}

// Accepted
public class Solution1 {
    public string DecodeCiphertext(string encodedText, int rows) {
        var len = encodedText.Length;
        var cols = len/rows;
        var matrix = new char[rows,cols];
        
        // fill up the matrix with encrypted text
        for(int i=0,chIdx=0; i<rows; i++)
            for(int j=0; j<cols; j++)
                matrix[i,j] = encodedText[chIdx++];
        
        
        // read decrypted text
        var sb = new StringBuilder();
        for(int colStart=0, i=0, r=0, c=0; i<len; i++,r++,c++){
            // if we crossed row limit, move to first row and next col
            if(r==rows){
                r = 0;
                c = ++colStart;
            }
            // if we crossed col limit, then we are done
            if(c == cols) break;
            
            // append decrypted text
            sb.Append(matrix[r,c]);
        }
        
        return sb.ToString().TrimEnd(); // remove trailing spaces
    }
}