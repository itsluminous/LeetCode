class Solution {
    public int peopleAwareOfSecret(int n, int delay, int forget) {
        var MOD = 1_000_000_007;
        
        var peopleWhoFoundSecret = new long[n+1]; // people who found secret on i-th day
        peopleWhoFoundSecret[1] = 1;  // on day 1, one person knnows secret
        long peopleSharingSecret = 0;

        // sliding window
        for(var day=2; day<=n ;day++){
            // if enough delay has passed, then people will share secret
            if(day > delay)
                peopleSharingSecret = (peopleSharingSecret + peopleWhoFoundSecret[day - delay]) % MOD;

            // if enough days have passed, some will forget secret
            // we do "+ MOD", to avoid negative numbers
            if(day > forget)
                peopleSharingSecret = (peopleSharingSecret - peopleWhoFoundSecret[day - forget] + MOD) % MOD;
            
            peopleWhoFoundSecret[day] = peopleSharingSecret;
        }

        // at the end, people who know secret are those who did not forget yet
        long ans = 0;
        for(var day = n - forget + 1; day <= n; day++)
            ans = (ans + peopleWhoFoundSecret[day]) % MOD;
        
        return (int)ans;
    }
}