public class Solution {
    public int MinimumDeletions(string s) {
        int n = s.Length, minDel = 0, b = 0;
        
        foreach(var ch in s){
            if(ch == 'b')
                b++;
            else
                minDel = Math.Min(minDel + 1, b);
        }

        return minDel;
    }
}