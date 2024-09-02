class Solution:
    def chalkReplacer(self, chalk: List[int], k: int) -> int:
        usage = sum(chalk)
        k %= usage

        for i, ch in enumerate(chalk):
            if ch > k: return i
            k -= ch
        return 0