public class Solution {
    public long CountSubstrings(string s, char c) {
        // count occurrence of char in string
        long n = s.Count(f => f == c);
        // calculate AP sum
        return n * (n+1) / 2;
    }
}