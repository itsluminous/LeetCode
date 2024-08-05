class Solution:
    def kthDistinct(self, arr: List[str], k: int) -> str:
        is_distinct = {}

        for string in arr:
            if string in is_distinct:
                is_distinct[string] = False
            else:
                is_distinct[string] = True

        for string in arr:
            if is_distinct[string]:
                k -= 1
                if k == 0: return string

        return ""