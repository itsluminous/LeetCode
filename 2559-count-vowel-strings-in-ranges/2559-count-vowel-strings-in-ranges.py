class Solution:
    def vowelStrings(self, words: List[str], queries: List[List[int]]) -> List[int]:
        vowels = ['a', 'e', 'i', 'o', 'u']
        w, q = len(words), len(queries)

        # create prefix array
        pre = [0] * (w + 1)
        for i in range(1, w + 1):
            word = words[i-1]
            first, last = word[0], word[-1]
            if first in vowels and last in vowels:
                pre[i] = pre[i-1] + 1
            else:
                pre[i] = pre[i-1]

        # update ans based on prefix array
        ans = [0] * q
        for i in range(q):
            start, end = queries[i][0], queries[i][1] + 1
            ans[i] = pre[end] - pre[start]

        return ans