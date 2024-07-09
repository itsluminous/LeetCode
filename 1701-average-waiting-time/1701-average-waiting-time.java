class Solution {
    public double averageWaitingTime(int[][] customers) {
        var n = customers.length;
        long wait = 0, time = 0;
        
        for(var cust : customers){
            if(time <= cust[0])
                time = cust[0] + cust[1];
            else
                time += cust[1];
            wait += (time - cust[0]);
        }

        return (wait * 1.0)/n;
    }
}