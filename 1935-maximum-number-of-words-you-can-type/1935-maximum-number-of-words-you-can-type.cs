public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) {
        var broken = new int[26];   // 1 if broken, 0 if not
        foreach (char ch in brokenLetters)
            broken[ch - 'a'] = 1;

        int ans = 0, curr = 0;
        foreach (char ch in text) {
            if (ch == ' ') {
                if (curr == 0) ans++;
                curr = 0;
            } 
            else
                curr += broken[ch - 'a'];
        }

        if (curr == 0) ans++;
        return ans;
    }
}

// Accepted - slow
public class Solution1 {
    public int CanBeTypedWords(string text, string brokenLetters) {
        var words = text.Split(' ');
        int broken = 0;

        foreach (var word in words) {
            foreach (char ch in brokenLetters) {
                if (word.Contains(ch)) {
                    broken++;
                    break;
                }
            }
        }

        return words.Length - broken;
    }
}