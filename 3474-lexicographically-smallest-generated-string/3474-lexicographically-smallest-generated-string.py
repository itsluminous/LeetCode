class Solution:
    def generateString(self, str1: str, str2: str) -> str:
        len1, len2 = len(str1), len(str2)
        lenSum = len1 + len2 - 1
        empty = '0'

        ans = [empty] * lenSum
        forced = [False] * lenSum

        # fill all chars for "T"
        # for "F", fill it with 'a', to keep lexicographically smallest
        for i in range(len1):
            if str1[i] == 'T':
                for j in range(len2):
                    if ans[i + j] == empty:
                        ans[i + j] = str2[j]
                        forced[i + j] = True
                    elif ans[i + j] != str2[j]:
                        return ""

        # Fill remaining empty chars with 'a'
        for i in range(lenSum):
            if ans[i] == empty:
                ans[i] = 'a'

        # Fix any "F" that matches str2
        for i in range(len1):
            if str1[i] == 'T': continue

            # check if this segment matches str2
            if all(ans[i + j] == str2[j] for j in range(len2)):
                # find a non-forced position from the end to change to 'b'
                for j in reversed(range(len2)):
                    if not forced[i + j]:
                        ans[i + j] = 'b'
                        break
                else:
                    return ""  # no possible modification

        return ''.join(ans)
