public class Solution {
    public string[] DivideString(string s, int k, char fill) {
        var len = s.Length;
        var n = len/k;
        string[] result = new string[n];
        // if there is some character left at the end, then array will need one more element
        if(len%k != 0) result = new string[n+1];

        // fill up all strings which fit perfectly
        for(var i=0; i<n; i++){
            var sub = s.Substring(i*k, k);
            result[i] = sub;
        }
        
        // fill last string with fill characters
        if(len%k != 0){
            var sb = new StringBuilder(s.Substring(n*k, len-(n*k)));
            for(var j=sb.Length; j<k; j++) sb.Append(fill.ToString());
            result[n] = sb.ToString();
        }
        
        return result;
    }
}