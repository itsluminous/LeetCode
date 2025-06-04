class Solution:
    def answerString(self, word: str, numFriends: int) -> str:
        if numFriends == 1: return word
        
        wordLen = len(word)
        maxLen = wordLen - numFriends + 1  # max length of ans
        
        # check all strings of size maxLen
        largest = word[0 : maxLen]
        for i in range(1, wordLen-maxLen+1):
            currWord = word[i : i+maxLen]
            if currWord > largest:
                largest = currWord

        # try all remaining chars at end (of size < maxLen)
        for i in range(wordLen-maxLen+1, wordLen):
            currWord = word[i : wordLen]
            if currWord > largest:
                largest = currWord

        return largest