public class Solution {
    public int MinSteps(int n) {
        var count = 0;
        while(n != 1){
            for(var div=2; div<=n; div++){
                if(n % div != 0) continue;
                n /= div;
                count += div;
                break;
            }
        }
        return count;
    }
}