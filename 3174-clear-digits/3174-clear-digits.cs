public class Solution {
    public string ClearDigits(string s) {
        var alpha = new StringBuilder();
        foreach(var ch in s)
            if(char.IsDigit(ch))
                alpha.Length--;   // alpha will always have something
            else
                alpha.Append(ch);
        
        return alpha.ToString();
    }
}