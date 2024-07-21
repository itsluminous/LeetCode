public class Solution {
    public int MaxOperations(string s) {
        int count = 0, prev = 0;

        for (var i = s.Length - 2; i >= 0; i--) {
            if (s[i] == '1') {
                prev = (s[i + 1] == '0') ? prev + 1 : prev;
                count += prev;
            }
        }

        return count;
    }
}