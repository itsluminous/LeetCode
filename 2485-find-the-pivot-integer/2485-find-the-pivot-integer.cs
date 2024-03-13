public class Solution {
    public int PivotInteger(int n) {
        int l=1, r=n, sumL = 1, sumR = n;
        while(l<r){
            if(sumL < sumR){
                 l++;
                 sumL += l;
            }
            else{
                r--;
                sumR += r;
            }
        }

        if( sumL == sumR) return r;
        return -1;
    }
}