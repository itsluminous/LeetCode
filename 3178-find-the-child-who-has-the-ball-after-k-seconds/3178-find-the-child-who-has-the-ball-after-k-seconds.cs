public class Solution {
    public int NumberOfChild(int n, int k) {
        n--;    // each round will go till (n-1) only

        var rounds = k / n;
        k %= n;

        // if even rounds, then left to right else right to left
        if((rounds & 1) == 1) return n - k;
        return k;
    }
}