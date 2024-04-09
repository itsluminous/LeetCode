public class Solution {
    public int timeRequiredToBuy(int[] tickets, int k) {
        var n = tickets.length;
        var ans = tickets[k];
        for(var i=0; i<n; i++){
            if(i == k) continue;
            
            if(tickets[i] < tickets[k])
                ans += tickets[i];
            else if(i<k)
                ans += tickets[k];
            else if(i >= k)
                ans += tickets[k]-1;
        }

        return ans;
    }
}