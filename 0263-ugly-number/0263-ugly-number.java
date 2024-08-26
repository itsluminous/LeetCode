class Solution {
    public boolean isUgly(int n) {
        for(var div=5; div>1 && n >0; div--)
            while(n % div == 0)
                n /= div;
        return n == 1;
    }
}