class Solution:
    def areSentencesSimilar(self, sentence1: str, sentence2: str) -> bool:
        shoort, loong = sentence1.split(), sentence2.split()
        if len(shoort) > len(loong):
            shoort, loong = loong, shoort
        
        sl, sr = 0, len(shoort)-1
        ll, lr = 0, len(loong)-1
        while sl <= sr and shoort[sl] == loong[ll]:
            sl += 1
            ll += 1
        
        while sr >= 0 and shoort[sr] == loong[lr]:
            sr -= 1
            lr -= 1

        return sr < sl