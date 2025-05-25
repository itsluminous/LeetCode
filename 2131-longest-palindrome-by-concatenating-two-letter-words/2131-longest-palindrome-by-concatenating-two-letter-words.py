class Solution:
    def longestPalindrome(self, words: List[str]) -> int:
        longest = same = 0
        count = [[0] * 26 for _ in range(26)]    # count of each word
        for word in words:
            c1, c2 = ord(word[0]) - ord('a'), ord(word[1]) - ord('a')
            if count[c1][c2] > 0:
                longest += 4
                count[c1][c2] -= 1
                if c1 == c2: same -= 1  # we used up one word with same letters
                continue
            
            count[c2][c1] += 1
            if c1 == c2: same += 1  # found word with same letters

        if same > 0: longest += 2  # the word with same letters can be put in center
        return longest

# Accepted - using dict
class SolutionDict:
    def longestPalindrome(self, words: List[str]) -> int:
        longest = same = 0
        count = defaultdict()  # count of each word
        for word in words:
            if count.get(word, 0) > 0:
                longest += 4
                count[word] -= 1
                if word[0] == word[1]: same -= 1  # we used up one word with same letters
                continue

            reversed = word[1] + word[0]
            count[reversed] = count.get(reversed, 0) + 1
            if word[0] == word[1]: same += 1  # found word with same letters

        if same > 0: longest += 2  # the word with same letters can be put in center
        return longest