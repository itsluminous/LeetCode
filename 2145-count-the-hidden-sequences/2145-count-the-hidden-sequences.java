class Solution {
    public int numberOfArrays(int[] differences, int lower, int upper) {
        var n = differences.length;
        var allowedGap = upper - lower;
        
        int num = 0, smallest = 0, largest = 0;
        for(var diff : differences){
            num += diff;
            smallest = Math.min(smallest, num);
            largest = Math.max(largest, num);

            if(largest - smallest > allowedGap) return 0;
        }
        return 1 + allowedGap - (largest - smallest);
    }
}