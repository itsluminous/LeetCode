class Solution {
    public String compressedString(String word) {
        int n = word.length(), count = 0;
        StringBuilder ans = new StringBuilder();

        var chars = word.toCharArray();
        int left = 0, right = 0;
        while (right < n) {
            count = 0;
            while (right < n && chars[left] == chars[right] && count < 9) {
                right++;
                count++;
            }
            ans.append(count).append(chars[left]);
            left = right;
        }
        return ans.toString();
    }
}