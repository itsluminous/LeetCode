class Solution:
    def findLatestTime(self, s: str) -> str:
        ans = list(s)

        if ans[0] == '?':
            ans[0] = '1' if ans[1] == '?' or ans[1] < '2' else '0'
        if ans[1] == '?':
            ans[1] = '1' if ans[0] == '1' else '9'
        if ans[3] == '?':
            ans[3] = '5'
        if ans[4] == '?':
            ans[4] = '9'

        return ''.join(ans)