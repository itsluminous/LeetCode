public class Solution {
    public string Convert(string s, int numRows) {
        var sb = new StringBuilder[numRows];
        for(var i=0; i<numRows; i++) sb[i] = new StringBuilder();

        int n = s.Length, idx = 0;
        while(idx < n){
            // fill down
            for(var i=0; i<numRows && idx < n; i++)
                sb[i].Append(s[idx++]);
                

            // fill diag up
            for(var i=numRows-2; i>0 && idx < n; i--)
                sb[i].Append(s[idx++]);
        }

        // concatenate all stringbuilders
        for(var i=1; i<numRows; i++) sb[0].Append(sb[i]);
        return sb[0].ToString();
    }
}