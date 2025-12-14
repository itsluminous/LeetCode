class Solution {
    public int numberOfWays(String corridor) {
        var MOD = 1_000_000_007;
        long ans = 1;
        int n = corridor.length(), totSeats = 0, seats = 0, start = 0;   // start means the first index till which we have exactly 2 seats

        for(var i=0; i<n; i++){
            if(corridor.charAt(i) == 'P') continue;
            
            // found seat
            totSeats++;
            seats++;
            
            if(seats == 2) start = i;   // found idx where we have exactly 2 seats
            else if(seats == 3){        // found idx where new seat group will start
                ans = (ans * (i - start)) % MOD;
                seats = 1;
            }
        }

        if((seats & 1) == 1) return 0;    // odd seats
        if(totSeats == 0) return 0; // only plants
        return (int)ans;
    }
}