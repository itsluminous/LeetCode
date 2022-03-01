public class Solution {
    public int[] CountBits(int n) {
        var result = new int[n+1];
        for(var i=0; i<=n; i++){
            result[i] = CountSetBits(i);
        }
        return result;
    }
    
    // Brian Kernighan’s Algorithm
    // the loop runs only for as many set bits we have
    private int CountSetBits(int n){
        var count = 0;
        while(n > 0){
            n &= (n-1);
            count++;
        }
        return count;
    }
}