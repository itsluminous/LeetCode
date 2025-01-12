public class Solution {
    public bool CanBeValid(string s, string locked) {
        var n = s.Length;
        if((n & 1) == 1) return false;  // odd length can never be balanced

        // check from left for '(' and from right for ')'
        return Validate(s, locked, '(', 0, 1) &&
               Validate(s, locked, ')', n-1, -1);
    }

    private bool Validate(string s, string locked, char op, int start, int dir){
        var n = s.Length;
        int bal = 0, free = 0;  // free will track all pos with bit = 0

        for(var i=start; i >= 0 && i < n && free + bal >= 0; i += dir){
            if(locked[i] == '1')
                bal += s[i] == op ? 1 : -1;
            else
                free++;
        }

        return Math.Abs(bal) <= free;
    }
}