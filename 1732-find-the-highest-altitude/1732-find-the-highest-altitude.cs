public class Solution {
    public int LargestAltitude(int[] gain) {
        int max = 0, curr = 0;
        foreach(var g in gain){
            curr += g;
            max = Math.Max(max, curr);
        }

        return max;
    }
}