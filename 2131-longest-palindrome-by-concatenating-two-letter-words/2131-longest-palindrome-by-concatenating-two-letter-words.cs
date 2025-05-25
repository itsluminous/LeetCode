public class Solution {
    public int LongestPalindrome(string[] words) {
        int longest = 0, same = 0;
        var count = new int[26,26];    // count of each word
        foreach(var word in words){
            int c1 = word[0] - 'a', c2 = word[1] - 'a';
            if(count[c1,c2] > 0){
                longest += 4;
                count[c1,c2]--;
                if(c1 == c2) same--;  // we used up one word with same letters
                continue;
            }
            
            count[c2,c1]++;
            if(c1 == c2) same++;  // found one word with same letters
        }

        if(same > 0) longest += 2;  // the word with same letters can be put in center
        return longest;
    }
}

// Accepted - using dictionary
public class SolutionDict {
    public int LongestPalindrome(string[] words) {
        int longest = 0, same = 0;
        var count = new Dictionary<string, int>();  // count of each word
        foreach(var word in words){
            if(count.ContainsKey(word) && count[word] > 0){
                longest += 4;
                count[word]--;
                if(word[0] == word[1]) same--;  // we used up one word with same letters
                continue;
            }

            var reversed = $"{word[1]}{word[0]}";
            if(count.ContainsKey(reversed)) count[reversed]++;
            else count[reversed] = 1;
            if(word[0] == word[1]) same++;  // found one word with same letters
        }

        if(same > 0) longest += 2;  // the word with same letters can be put in center
        return longest;
    }
}