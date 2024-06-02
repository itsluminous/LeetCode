public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);

        var overlaping = new List<int[]>();
        var curr = meetings[0];
        overlaping.Add(curr);

        foreach (var m in meetings) {
            if (m[0] <= curr[1]) {
                curr[1] = Math.Max(curr[1], m[1]);
            } 
            else {
                curr = m;
                overlaping.Add(curr);
            }
        }

        var count = 0;
        if (overlaping[0][0] > 1)
            count += overlaping[0][0] - 1;

        for (var i = 1; i < overlaping.Count; i++)
            count += overlaping[i][0] - overlaping[i - 1][1] - 1;

        if (overlaping[overlaping.Count - 1][1] < days)
            count += days - overlaping[overlaping.Count - 1][1];

        return count;
    }
}