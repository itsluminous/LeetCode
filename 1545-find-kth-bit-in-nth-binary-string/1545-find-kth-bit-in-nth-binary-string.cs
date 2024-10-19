public class Solution {
    public char FindKthBit(int n, int k) {
        // base case
        if(n == 1) return '0';

        // length of the final string possible (2^n)
        var len = 1 << n;

        // exact middle of str will always be 1
        if(k == len/2) return '1';  
        // if result is in left half
        if(k < len/2) return FindKthBit(n-1, k); 
        // kth bit in right half is same as inverse of len-k bit in left
        var ans = FindKthBit(n-1, len-k);
        return  ans == '0' ? '1' : '0';
    }
}