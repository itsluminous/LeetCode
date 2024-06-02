public class Solution {
    public int MinimumChairs(string s) {
        int min = 0, curr = 0;
        foreach(var ch in s){
            if(ch == 'E') curr--;
            else curr++;

            min = Math.Min(min, curr);
        }

        if(min < 0) return -min;
        return 0;
    }
}