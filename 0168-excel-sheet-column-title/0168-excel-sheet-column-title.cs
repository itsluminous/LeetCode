public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var ans = new StringBuilder();
        while(columnNumber > 0){
            columnNumber--;
            var remainder = columnNumber % 26;
            columnNumber /= 26;

            var ch = (char) ('A' + remainder);
            ans.Append(ch);
        }

        return new string(ans.ToString().Reverse().ToArray());
    }
}