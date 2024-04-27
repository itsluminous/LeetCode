class Solution {
    public int minEatingSpeed(int[] piles, int h) {
        int left = 1, right = 1_000_000_000;
        while(left < right){
            var mid = left + (right-left)/2;
            var hourTaken = 0;
            for(var pile : piles) hourTaken += (pile+mid-1) / mid;     // add hours taken for each pile
            
            if(hourTaken > h) left = mid+1;     // eating too slow
            else right = mid;                   // this will fit, but lets see if we can go slower
        }

        return left;
    }
}