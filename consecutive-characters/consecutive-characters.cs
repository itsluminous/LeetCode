public class Solution {
    public int MaxPower(string s) {
        int max = 1, curr = 1;
        for(var i=1; i<s.Length; i++){
            if(s[i] != s[i-1]){
                max = Math.Max(max, curr);
                curr = 1;
            }
            else curr++;
        }
        
        return Math.Max(max, curr);
    }
}