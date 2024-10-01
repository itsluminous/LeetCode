class Solution:
    def canArrange(self, arr: List[int], k: int) -> bool:
        freq = [0] * k
        for num in arr:
            mod = num % k
            if mod < 0: mod += k
            remaining = 0 if mod == 0 else k - mod

            if freq[remaining] > 0: freq[remaining] -= 1
            else: freq[mod] += 1
        return sum(freq) == 0