public class Solution {
    public int TitleToNumber(string columnTitle) {
        int val = 0, n = columnTitle.Length;
        
        for(int i=n-1, pos = 1; i>=0; i--, pos *= 26){
            var curr = columnTitle[i]-'A'+ 1;
            val += pos*curr;
        }
        
        return val;
    }
}