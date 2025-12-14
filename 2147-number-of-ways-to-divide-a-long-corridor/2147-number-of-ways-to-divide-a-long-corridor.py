class Solution:
    def numberOfWays(self, corridor: str) -> int:
        MOD = 1_000_000_007
        ans, n, totSeats, seats, start = 1, len(corridor), 0, 0, 0  # start means the first index till which we have exactly 2 seats

        for i in range(n):
            if(corridor[i] == 'P'): continue
            
            # found seat
            totSeats += 1
            seats += 1
            
            if seats == 2: start = i    # found idx where we have exactly 2 seats
            elif seats == 3:            # found idx where new seat group will start
                ans = (ans * (i - start)) % MOD
                seats = 1

        if (seats & 1) == 1: return 0    # odd seats
        if totSeats == 0: return 0 # only plants
        return ans