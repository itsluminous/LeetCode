// 1 pass - we only care about relative min, not accurate value
public class Solution {
    public int BestClosingTime(string customers) {
        var n = customers.Length;
        int currPenalty = 0, minPenalty = 0, minIdx = 0;

        for(var i=0; i<n; i++){
            if(customers[i] == 'Y') currPenalty--;
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
public class Solution2Pass {
    public int BestClosingTime(String customers) {
        var n = customers.Length;
        var penalty = new int[n+1];

        for(var i=n-1; i>=0; i--){
            penalty[i] = penalty[i+1];
            if(customers[i] == 'Y') penalty[i]++;
        }

        int minPenalty = penalty[0], minIdx = 0, noCust = 0;
        for(var i=1; i<=n; i++){
            if(customers[i-1] == 'N') noCust++;
            penalty[i] += noCust;
            if(penalty[i] < minPenalty){
                minPenalty = penalty[i];
                minIdx = i;
            }
        }

        return minIdx;
    }
}