class Solution {
    public int[] findMissingAndRepeatedValues(int[][] grid) {
        var n = grid.length * grid.length;
        int currSum = 0, dup = 0;
        var uniq = new HashSet<Integer>();

        for(var row : grid)
            for(var num : row)
                if(!uniq.add(num))
                    dup = num;
                else
                    currSum += num;
        
        var expectedSum = (n * (n + 1)) / 2;
        var missing = expectedSum - currSum;
        return new int[]{dup, missing};
    }
}