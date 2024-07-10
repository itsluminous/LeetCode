public class Solution {
    public int MinOperations(string[] logs) {
        var depth = 0;
        foreach(var cmd in logs){
            if(cmd.Equals("../") && depth > 0)
                depth--;
            else if(cmd[0] != '.')
                depth++;
        }
        return depth;
    }
}