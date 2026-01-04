public class Solution {
    public int MinDeletionSize(string[] strs) {
        int delete = 0;
        int n = strs.Length, m = strs[0].Length;
        for (var i = 0; i < m; i++) {
            for (var j = 1; j < n; j++) {
                if (strs[j][i] < strs[j - 1][i]) {
                    delete++;
                    break;
                }
            }
        }
        return delete;
    }
}