public class Solution {
    public string CompressedString(string word) {
        int n = word.Length, count = 0;
        StringBuilder ans = new StringBuilder();

        int left = 0, right = 0;
        while (right < n) {
            count = 0;
            while (right < n && word[left] == word[right] && count < 9) {
                right++;
                count++;
            }
            ans.Append(count).Append(word[left]);
            left = right;
        }
        return ans.ToString();
    }
}