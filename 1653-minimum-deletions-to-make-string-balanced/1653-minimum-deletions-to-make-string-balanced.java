class Solution {
    public int minimumDeletions(String s) {
        int minDel = 0, b = 0;
        for(var ch : s.toCharArray()){
            if(ch == 'b')
                b++;
            else
                minDel = Math.min(minDel + 1, b);
        }

        return minDel;
    }
}