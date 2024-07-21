public class Solution {
    public int MinChanges(int n, int k) {
        if(n == k) return 0;
        if(n < k) return -1;

        var xor = n ^ k;
        if((k & ~n) != 0) return -1;

        return BitOperations.PopCount((uint)xor);
    }
}