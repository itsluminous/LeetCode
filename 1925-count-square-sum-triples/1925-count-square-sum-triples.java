class Solution {
    public int countTriples(int n) {
        var count = 0;
        
        for(var n1=1; n1<=n; n1++){
            for(var n2=1; n2<=n; n2++){
                var sum = n1*n1 + n2*n2;
                var n3 = (int) Math.sqrt(sum);
                if(n3 <= n && n3*n3 == sum) count++;
            }
        }

        return count;
    }
}