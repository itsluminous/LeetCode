class Solution {
    public int minimumChairs(String s) {
        int min = 0, curr = 0;
        for(var ch : s.toCharArray()){
            if(ch == 'E') curr--;
            else curr++;

            min = Math.min(min, curr);
        }

        if(min < 0) return -min;
        return 0;
    }
}