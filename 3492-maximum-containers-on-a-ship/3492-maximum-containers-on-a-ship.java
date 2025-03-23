class Solution {
    public int maxContainers(int n, int w, int maxWeight) {
        var maxCellAllowed = maxWeight / w;
        var cellGiven = n * n;
        return Math.min(maxCellAllowed, cellGiven);
    }
}