public class Solution {
    public string LargestGoodInteger(string num) {
        var maxChar = '#';  // any char before 0 in ascii
        for(var i=0; i<=num.Length-3; i++){
            if(num[i] == num[i+1] && num[i] == num[i+2])
                maxChar = (char)Math.Max(maxChar, num[i]);
        }

        if(maxChar == '#') return "";
        var sb = new StringBuilder();
        sb.Append(maxChar).Append(maxChar).Append(maxChar);
        return sb.ToString();
    }
}