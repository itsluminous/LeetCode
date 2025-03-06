public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        var n = grid.Length * grid.Length;
        int currSum = 0, dup = 0;
        var uniq = new HashSet<int>();

        foreach(var row in grid)
            foreach(var num in row)
                if(!uniq.Add(num))
                    dup = num;
                else
                    currSum += num;
        
        var expectedSum = (n * (n + 1)) / 2;
        var missing = expectedSum - currSum;
        return [dup, missing];
    }
}