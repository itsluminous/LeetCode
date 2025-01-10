class Solution:
    def wordSubsets(self, words1: List[str], words2: List[str]) -> List[str]:
        # find max freq of each char from words2
        freq = [0] * 26
        for word in words2:
            mapp = {}
            for ch in word:
                mapp[ch] = mapp.get(ch, 0) + 1

                # update the freq of curr char
                freq[ord(ch)-ord('a')] = max(freq[ord(ch)-ord('a')], mapp[ch])

        # find words which satisfy all conditions of freq
        ans = []
        for word in words1:
            frq = freq[:]
            for ch in word:
                if frq[ord(ch)-ord('a')] == 0: continue  # this char is not needed
                frq[ord(ch)-ord('a')] -= 1

            # check if all chars were covered
            if sum(frq) == 0: ans.append(word)

        return ans