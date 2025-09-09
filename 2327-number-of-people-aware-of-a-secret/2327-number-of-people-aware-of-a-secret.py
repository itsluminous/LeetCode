class Solution:
    def peopleAwareOfSecret(self, n: int, delay: int, forget: int) -> int:
        MOD = 1_000_000_007
        
        peopleWhoFoundSecret = [0] * (n+1) # people who found secret on i-th day
        peopleWhoFoundSecret[1] = 1  # on day 1, one person knnows secret
        peopleSharingSecret = 0

        # sliding window
        for day in range(2, n+1):
            # if enough delay has passed, then people will share secret
            if day > delay:
                peopleSharingSecret += peopleWhoFoundSecret[day - delay]

            # if enough days have passed, some will forget secret
            if day > forget:
                peopleSharingSecret -= peopleWhoFoundSecret[day - forget]
            
            peopleWhoFoundSecret[day] = peopleSharingSecret

        # at the end, people who know secret are those who did not forget yet
        ans = 0
        for day in range(n - forget + 1, n+1):
            ans += peopleWhoFoundSecret[day]
        
        return ans % MOD