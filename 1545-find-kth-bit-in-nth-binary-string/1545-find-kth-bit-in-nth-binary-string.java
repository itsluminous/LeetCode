class Solution {
    public char findKthBit(int n, int k) {
        // base case
        if(n == 1) return '0';

        // length of the final string possible (2^n)
        var len = 1 << n;

        // exact middle of str will always be 1
        if(k == len/2) return '1';  
        // if result is in left half
        if(k < len/2) return findKthBit(n-1, k); 
        // kth bit in right half is same as inverse of len-k bit in left
        var ans = findKthBit(n-1, len-k);
        return  ans == '0' ? '1' : '0';
    }
}

// Accepted - brute force
class SolutionBF {
    public char findKthBit(int n, int k) {
        if(k == 1) return '0';

        var str = "0";
        for(var i=2; i<=n; i++){
            str = revInverse(str);
            if(str.length() >= k)
                return str.charAt(k-1);
        }

        return '0';
    }

    private String revInverse(String str){
        var sb = new StringBuilder();
        sb.append(str).append("1");

        for(var i=str.length()-1; i>=0; i--){
            if(str.charAt(i) == '0') sb.append('1');
            else sb.append('0');
        }
        return sb.toString();
    }
}