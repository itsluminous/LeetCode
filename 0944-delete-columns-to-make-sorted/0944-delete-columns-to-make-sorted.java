class Solution {
    public int minDeletionSize(String[] strs) {
        int delete = 0;
        int n = strs.length, m = strs[0].length();
        for (var i = 0; i < m; i++) {
            for (var j = 1; j < n; j++) {
                if (strs[j].charAt(i) < strs[j - 1].charAt(i)) {
                    delete++;
                    break;
                }
            }
        }
        return delete;
    }
}