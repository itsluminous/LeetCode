class Solution:
    def compress(self, chars: List[str]) -> int:
        n, idx, prev, count = len(chars), 0, chars[0], 1
        for i in range(1, n):
            if chars[i] == prev: count += 1
            elif count == 1:
                chars[idx] = prev
                idx += 1
                prev = chars[i]
            else:
                chars[idx] = prev
                idx += 1
                for ch in str(count):
                    chars[idx] = ch
                    idx += 1
                count = 1
                prev = chars[i]

        chars[idx] = prev
        idx += 1
        if count > 1:
            for ch in str(count):
                chars[idx] = ch
                idx += 1

        return idx