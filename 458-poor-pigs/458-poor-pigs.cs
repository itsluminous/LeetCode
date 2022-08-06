public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
        int factor = minutesToTest / minutesToDie, pigs = 0;
        while(Math.Pow(factor+1, pigs) < buckets)
            pigs++;
        return pigs;
    }
}