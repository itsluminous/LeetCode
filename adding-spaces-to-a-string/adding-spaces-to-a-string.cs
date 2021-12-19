public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder();
        var currIdx = 0;
        for(var i=0; i<spaces.Length; i++){
            sb.Append(s.Substring(currIdx,spaces[i]-currIdx));
            sb.Append(" ");
            currIdx = spaces[i];
        }
        sb.Append(s.Substring(currIdx));
        
        return sb.ToString();
    }
}

// TLE - when doint Insert in stringbuilder
public class Solution1 {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder(s);
        for(var i=spaces.Length-1; i>=0; i--){
            sb.Insert(spaces[i], " ");
        }
        
        return sb.ToString();
    }
}