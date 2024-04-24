public class Solution {
    public int tribonacci(int n) {
        var t = new int[]{0, 1, 1};
        if(n < 3) return t[n];

        for(var i=3; i<=n; i++){
            var num = Arrays.stream(t).sum();
            t = new int[]{t[1], t[2], num};
        }

        return t[2];
    }
}