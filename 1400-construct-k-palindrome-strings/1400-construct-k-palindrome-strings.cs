public class Solution {
    public bool CanConstruct(string s, int k) {
        if (s.Length < k) return false;
        if (s.Length == k) return true;

        var freq = new int[26];
        foreach(var ch in s)
            freq[ch - 'a']++;

        // count how many freq are odd
        var odd = 0;
        foreach(var num in freq)
            if ((num & 1) == 1) odd++;

        // each odd freq will need to be in a separate palindrome string
        return odd <= k;
    }
}