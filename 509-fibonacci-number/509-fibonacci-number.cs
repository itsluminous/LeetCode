public class Solution {
    public int Fib(int n) {
        if(n < 2) return n;
        
        int prev = 1, prePrev = 0, temp;
        for(int i=2; i<=n; i++){
            temp = prev;
            prev += prePrev;
            prePrev = temp;
        }
        return prev;
    }
    
}