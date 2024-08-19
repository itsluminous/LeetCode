class Solution {
public:
    int minSteps(int n) {
        auto count = 0;
        while(n != 1){
            for(auto div=2; div<=n; div++){
                if(n % div != 0) continue;
                n /= div;
                count += div;
                break;
            }
        }
        return count;
    }
};