class Solution:
    def longestSubsequenceRepeatedK(self, s: str, k: int) -> str:
        freq = [0] * 26
        for ch in s:
            freq[ord(ch) - ord('a')] += 1
        
        # find all chars which repeat >= k 
        # in desc order (to get lexicographically largest answer)
        chars = []
        for i in range(25, -1, -1):
            if freq[i] >= k:
                chars.append(chr(ord('a') + i))
        
        # Create a queue to try all subsequences
        # Starting with single letter subsequence
        queue = deque()
        for ch in chars:
            queue.append(ch)
        
        ans = ""
        while queue:
            curr = queue.popleft()
            if len(curr) > len(ans):
                ans = curr
            # generate next candidate by enumerating over all chars >= k
            for ch in chars:
                next_seq = curr + ch
                if self.isKRepeatedSubsequence(s, next_seq, k):
                    queue.append(next_seq)
        
        return ans

    def isKRepeatedSubsequence(self, s: str, t: str, k: int) -> bool:
        t_len, t_idx, match_count = len(t), 0, 0
        for ch in s:
            if ch == t[t_idx]:
                t_idx += 1
                # found full match of substring
                if t_idx == t_len:
                    t_idx = 0   # check for next occurrence
                    match_count += 1
                    if match_count == k:  # found k occurrences of substring
                        return True
        return False