class Solution:
    def uncommonFromSentences(self, s1: str, s2: str) -> List[str]:
        s1words, s1once = self.makeSets(s1)
        s2words, s2once = self.makeSets(s2)

        s1once.difference_update(s2words)
        s2once.difference_update(s1words)
        s1once.update(s2once)
        
        return list(s1once)

    def makeSets(self, s):
        words = set()
        once = set()

        for word in s.split():
            if word in once:
                once.remove(word)
            elif word not in words:
                words.add(word)
                once.add(word)

        return words, once