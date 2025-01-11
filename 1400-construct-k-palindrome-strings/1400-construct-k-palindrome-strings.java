class Solution {
    public boolean canConstruct(String s, int k) {
        if (s.length() < k) return false;
        if (s.length() == k) return true;

        var freq = new int[26];
        for(var ch : s.toCharArray())
            freq[ch - 'a']++;

        // count how many freq are odd
        var odd = 0;
        for(var num : freq)
            if ((num & 1) == 1) odd++;

        // each odd freq will need to be in a separate palindrome string
        return odd <= k;
    }
}