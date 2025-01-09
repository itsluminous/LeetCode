public class Solution {
    public int PrefixCount(string[] words, string pref) {
        return words.Where(w => w.StartsWith(pref)).Count();
    }
}