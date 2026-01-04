// 1 pass - we only care about relative min, not accurate value
class Solution {
    public int bestClosingTime(String customers) {
        var n = customers.length();
        int currPenalty = 0, minPenalty = 0, minIdx = 0;

        for(var i=0; i<n; i++){
            if(customers.charAt(i) == 'Y') currPenalty--;
            else currPenalty++;

            if(currPenalty < minPenalty){
                minPenalty = currPenalty;
                minIdx = i+1;
            }
        }

        return minIdx;
    }
}

// Accepted - 2 pass
class Solution2Pass {
    public int bestClosingTime(String customers) {
        var n = customers.length();
        var penalty = new int[n+1];

        for(var i=n-1; i>=0; i--){
            penalty[i] = penalty[i+1];
            if(customers.charAt(i) == 'Y') penalty[i]++;
        }

        int minPenalty = penalty[0], minIdx = 0, noCust = 0;
        for(var i=1; i<=n; i++){
            if(customers.charAt(i-1) == 'N') noCust++;
            penalty[i] += noCust;
            if(penalty[i] < minPenalty){
                minPenalty = penalty[i];
                minIdx = i;
            }
        }

        return minIdx;
    }
}