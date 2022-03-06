public class Solution {
    public IList<string> CellsInRange(string s) {
        var result = new List<string>();
        
        for(var ch = s[0]; ch <= s[3]; ch++){
            for(var num = s[1]; num <= s[4]; num++){
                result.Add(ch + num.ToString());
            }
        }
        
        return result;
    }
}