// maintain a sliding window of `minutes` size and keep track of how many extra are satisfied in that
class Solution {
    public int maxSatisfied(int[] customers, int[] grumpy, int minutes) {
        var n = customers.length;

        // how many can be satisfied without any trickery
        var defaultSatisfied = 0;
        for(var i=0; i<n; i++)
            if(grumpy[i] == 0) defaultSatisfied += customers[i];

        // now figure out how many can be satisfied by using secret technique
        int maxExtraSatisfied = 0, currExtraSatisfied = 0;
        for(var i=0; i<minutes; i++)
            if(grumpy[i] == 1) currExtraSatisfied += customers[i];
        maxExtraSatisfied = currExtraSatisfied;

        // try to shift window one by one and see how many exta we can satisfy
        int left = 0, right = minutes;
        while(right < n){
            if(grumpy[left] == 1) currExtraSatisfied -= customers[left];
            if(grumpy[right] == 1) currExtraSatisfied += customers[right];

            maxExtraSatisfied = Math.max(maxExtraSatisfied, currExtraSatisfied);
            left++;
            right++;
        }
        
        return defaultSatisfied + maxExtraSatisfied;
    }
}