class Solution {
    public int numberOfBeams(String[] bank) {
        int prev = 0, curr = 0, sum = 0;
        for(var bnk : bank){
            curr = 0;
            for(var ch : bnk.toCharArray())
                if(ch == '1') curr++;
            sum += curr * prev;
            if(curr != 0)
                prev = curr;
        }
        return sum;
    }
}