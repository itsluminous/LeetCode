public class Solution {
    public int PrefixCount(string[] words, string pref) {
        var prefWords = words.Where(w => w.StartsWith(pref)).ToList();
        return prefWords.Count;
    }
}