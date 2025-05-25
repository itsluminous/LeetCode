class Solution {
    public int longestPalindrome(String[] words) {
        int longest = 0, same = 0;
        var count = new int[26][26];    // count of each word
        for(var word : words){
            int c1 = word.charAt(0) - 'a', c2 = word.charAt(1) - 'a';
            if(count[c1][c2] > 0){
                longest += 4;
                count[c1][c2]--;
                if(c1 == c2) same--;  // we used up one word with same letters
                continue;
            }
            
            count[c2][c1]++;
            if(c1 == c2) same++;  // found word with same letters
        }

        if(same > 0) longest += 2;  // the word with same letters can be put in center
        return longest;
    }
}

// Accepted - using map
class SolutionMap {
    public int longestPalindrome(String[] words) {
        int longest = 0, same = 0;
        var count = new HashMap<String, Integer>();  // count of each word
        for(var word : words){
            if(count.containsKey(word) && count.get(word) > 0){
                longest += 4;
                count.put(word, count.get(word) - 1);
                if(word.charAt(0) == word.charAt(1)) same--;  // we used up one word with same letters
                continue;
            }

            var reversed = "" + word.charAt(1) + word.charAt(0);
            count.put(reversed, count.getOrDefault(reversed, 0) + 1);
            if(word.charAt(0) == word.charAt(1)) same++;  // found word with same letters
        }

        if(same > 0) longest += 2;  // the word with same letters can be put in center
        return longest;
    }
}