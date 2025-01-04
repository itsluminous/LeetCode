class Solution {
    public int countPalindromicSubsequence(String s) {
        var n = s.length();
        int[] first = new int[26], last = new int[26];
        for(var i = 0; i < 26; i++) first[i] = n;

        for(var i = 0; i < n; i++) {
            char ch = s.charAt(i);
            first[ch - 'a'] = Math.min(first[ch - 'a'], i);
            last[ch - 'a'] = i;
        }

        var ans = 0;
        for(var i = 0; i < 26; i++) {
            if(first[i] + 1 < last[i]) {
                var uniqueChars = new HashSet<Character>();
                for (var j = first[i] + 1; j < last[i]; j++)
                    uniqueChars.add(s.charAt(j));
                ans += uniqueChars.size();
            }
        }

        return ans;
    }
}