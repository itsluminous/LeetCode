public class Solution {
    public string SortVowels(string s) {
        var chars = s.ToCharArray();
        var allVowels = new HashSet<char>{ 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        // find all vowels and sort them
        var vowels = new List<char>();
        foreach (var ch in chars) {
            if (allVowels.Contains(ch))
                vowels.Add(ch);
        }
        vowels.Sort();

        // replaces vowels in string with sorted vowels
        int idx = 0;
        for (int i = 0; i < chars.Length; i++) {
            if (allVowels.Contains(chars[i]))
                chars[i] = vowels[idx++];
        }

        // build updated string and return
        var ans = new StringBuilder();
        foreach (var ch in chars) ans.Append(ch);
        return ans.ToString();
    }
}
