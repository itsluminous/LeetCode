class Solution:
    def spellchecker(self, wordlist: List[str], queries: List[str]) -> List[str]:
        words = set(wordlist)
        capital = {}  # normalise case
        vowel = {}    # normalise vowels

        for word in wordlist:
            upper = word.upper()
            devowel = re.sub(r'[AEIOU]', '#', upper)
            capital.setdefault(upper, word)
            vowel.setdefault(devowel, word)

        for i in range(len(queries)):
            query = queries[i]
            if query in words: continue  # no change needed
            
            upper = query.upper()
            devowel = re.sub(r'[AEIOU]', '#', upper)
            if upper in capital:
                queries[i] = capital[upper]
            elif devowel in vowel:
                queries[i] = vowel[devowel]
            else:
                queries[i] = ""

        return queries