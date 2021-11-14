public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        var seconds = 0;
        var i=0;
        while(true){
           if(tickets[i] != 0){
                tickets[i]--;
                seconds++;
                if(i == k && tickets[i] == 0)
                    break;
            } 
            i = (i+1)%tickets.Length;
        }
        
        return seconds;
    }
}