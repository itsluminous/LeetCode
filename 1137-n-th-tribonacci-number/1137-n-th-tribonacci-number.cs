public class Solution {
    public int Tribonacci(int n) {
        var t = new []{0, 1, 1};
        if(n < 3) return t[n];

        for(var i=3; i<=n; i++)
            t = [t[1], t[2], t.Sum()];

        return t[2];
    }
}