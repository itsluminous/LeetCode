class Solution:
    def divideString(self, s: str, k: int, fill: str) -> List[str]:
        n = len(s)
        groups = (n + k - 1) // k   # how many groups can we make with s
        ans = []

        # split s into groups
        for i in range(groups):
            ans.append(s[i*k : min(n, (i+1)*k)])
        
        # fill extra chars in last word if applicable
        if len(ans[-1]) < k:
            sb = []
            sb.append(ans[groups-1])
            for i in range(len(ans[groups-1]), k):
                sb.append(fill)
            ans[-1] = ''.join(sb)

        return ans