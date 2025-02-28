class Solution:
    def shortestCommonSupersequence(self, str1: str, str2: str) -> str:
        dp = self.longestCommonSubsequence(str1, str2)

        # backtrack dp to make final supersequence
        sb = []
        idx1, idx2 = len(str1), len(str2)

        while idx1 > 0 and idx2 > 0:
            # if chars match
            if str1[idx1-1] == str2[idx2-1]:
                sb.append(str1[idx1-1])
                idx1 -= 1
                idx2 -= 1
            # if picking str1's char gave smaller supersequence
            elif dp[idx1-1][idx2] < dp[idx1][idx2-1]:
                idx1 -= 1
                sb.append(str1[idx1])
            # if picking str2's char gave smaller supersequence
            else:
                idx2 -= 1
                sb.append(str2[idx2])

        # append remaining chars from str1
        while idx1 > 0:
            idx1 -= 1
            sb.append(str1[idx1])
        
        # append remaining chars from str2
        while idx2 > 0:
            idx2 -= 1
            sb.append(str2[idx2])


        return ''.join(sb[::-1])

    def longestCommonSubsequence(self, str1: str, str2: str):
        len1, len2 = len(str1), len(str2)

        # dp to store length of longest supersequence for any length of str1 & str2
        dp = [[0] * (len2 + 1) for _ in range(len1 + 1)]

        # when str2 is empty, the supersequence len will be equal to len of str1
        for i in range(len1 + 1):
            dp[i][0] = i
        
        # when str1 is empty, the supersequence len will be equal to len of str2
        for i in range(len2 + 1):
            dp[0][i] = i
        
        # fill DP
        for idx1 in range(1, len1+1):
            for idx2 in range(1, len2+1):
                # if chars match, we can use prev diagonal val
                if str1[idx1-1] == str2[idx2-1]:
                    dp[idx1][idx2] = 1 + dp[idx1-1][idx2-1]
                # else we need to pick char from either str1 or str2, whichever gives smaller supersequence
                else:
                    dp[idx1][idx2] = 1 + min(dp[idx1-1][idx2], dp[idx1][idx2-1])

        return dp