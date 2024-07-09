public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        var n = customers.Length;
        long wait = 0, time = 0;
        
        foreach(var cust in customers){
            if(time <= cust[0])
                time = cust[0] + cust[1];
            else
                time += cust[1];
            wait += (time - cust[0]);
        }

        return (wait * 1.0)/n;
    }
}