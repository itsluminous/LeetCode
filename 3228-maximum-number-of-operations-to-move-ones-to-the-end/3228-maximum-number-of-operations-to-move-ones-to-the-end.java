class Solution {
    public int maxOperations(String s) {
        int count = 0, prev = 0;

        for (var i = s.length() - 2; i >= 0; i--) {
            if (s.charAt(i) == '1') {
                prev = (s.charAt(i + 1) == '0') ? prev + 1 : prev;
                count += prev;
            }
        }

        return count;
    }
}