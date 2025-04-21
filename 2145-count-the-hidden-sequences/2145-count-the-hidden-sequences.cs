public class Solution {
    public int NumberOfArrays(int[] differences, int lower, int upper) {
        var n = differences.Length;
        var allowedGap = upper - lower;
        
        int num = 0, smallest = 0, largest = 0;
        foreach(var diff in differences){
            num += diff;
            smallest = Math.Min(smallest, num);
            largest = Math.Max(largest, num);

            if(largest - smallest > allowedGap) return 0;
        }
        return 1 + allowedGap - (largest - smallest);
    }
}