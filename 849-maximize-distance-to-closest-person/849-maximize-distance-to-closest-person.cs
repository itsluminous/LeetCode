public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int start = 0, n = seats.Length;
        while(seats[start] != 1) start++; // find point of first person sitting
        var max = start;                   // because Alex can sit at 0th index
        
        // find max distance between any 2 people
        for(var i=start+1; i<n; i++){
            if(seats[i] == 0) continue;
            var curr = i-start;
            max = Math.Max(max, curr/2);
            start = i;
        }
        
        // if last seat is empty, then Alex can sit on last seat
        if(seats[n-1] != 1){
            var curr = n-1-start;
            max = Math.Max(max, curr);
        }
        
        return max;
    }
}