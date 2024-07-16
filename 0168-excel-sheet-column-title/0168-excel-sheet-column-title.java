class Solution {
    public String convertToTitle(int columnNumber) {
        var ans = new StringBuilder();
        while(columnNumber > 0){
            columnNumber--;
            var remainder = columnNumber % 26;
            columnNumber /= 26;

            var ch = (char) ('A' + remainder);
            ans.append(ch);
        }

        return ans.reverse().toString();
    }
}