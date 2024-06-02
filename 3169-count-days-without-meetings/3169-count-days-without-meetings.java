class Solution {
    public int countDays(int days, int[][] meetings) {
        Arrays.sort(meetings, (a, b) -> Integer.compare(a[0], b[0]));

        var overlaping = new ArrayList<int[]>();
        var curr = meetings[0];
        overlaping.add(curr);

        for (var m : meetings) {
            if (m[0] <= curr[1]) {
                curr[1] = Math.max(curr[1], m[1]);
            } 
            else {
                curr = m;
                overlaping.add(curr);
            }
        }

        var count = 0;
        if (overlaping.get(0)[0] > 1)
            count += overlaping.get(0)[0] - 1;

        for (var i = 1; i < overlaping.size(); i++)
            count += overlaping.get(i)[0] - overlaping.get(i - 1)[1] - 1;

        if (overlaping.get(overlaping.size() - 1)[1] < days)
            count += days - overlaping.get(overlaping.size() - 1)[1];

        return count;
    }
}