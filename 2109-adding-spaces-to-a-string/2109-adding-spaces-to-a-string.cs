public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder();
        int idx = 0, maxIdx = spaces.Length;
        for(var i=0; i<s.Length; i++){         
            if(idx < maxIdx && i == spaces[idx]){
                sb.Append(" ");
                idx += 1;
            }    
            sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
}