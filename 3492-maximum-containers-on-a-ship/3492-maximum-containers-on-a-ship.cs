public class Solution {
    public int MaxContainers(int n, int w, int maxWeight) {
        var maxCellAllowed = maxWeight / w;
        var cellGiven = n * n;
        return Math.Min(maxCellAllowed, cellGiven);
    }
}