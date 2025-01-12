class Solution {
    public boolean canBeValid(String s, String locked) {
        var n = s.length();
        if((n & 1) == 1) return false;  // odd length can never be balanced

        // check from left for '(' and from right for ')'
        return validate(s, locked, '(', 0, 1) &&
               validate(s, locked, ')', n-1, -1);
    }

    private boolean validate(String s, String locked, char op, int start, int dir){
        var n = s.length();
        int bal = 0, free = 0;  // free will track all pos with bit = 0

        for(var i=start; i >= 0 && i < n && free + bal >= 0; i += dir){
            if(locked.charAt(i) == '1')
                bal += s.charAt(i) == op ? 1 : -1;
            else
                free++;
        }

        return Math.abs(bal) <= free;
    }
}