public class Solution {
    public bool BackspaceCompare(string s, string t) {
        StringBuilder sbs = new StringBuilder(), sbt = new StringBuilder();
        
        foreach(var ch in s)
            if(ch != '#')   sbs.Append(ch);
            else if(sbs.Length > 0) sbs.Length--;
        
        foreach(var ch in t)
            if(ch != '#')   sbt.Append(ch);
            else if(sbt.Length > 0) sbt.Length--;
        
        return string.Equals(sbs.ToString(), sbt.ToString());
    }
}