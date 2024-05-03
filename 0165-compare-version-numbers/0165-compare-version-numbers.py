class Solution:
    def compareVersion(self, version1: str, version2: str) -> int:
        v1, v2 = version1.split('.'), version2.split('.')
        len1, len2 = len(v1), len(v2)
        length = max(len1, len2)

        for i in range(length):
            val1 = int(v1[i]) if i < len1 else 0
            val2 = int(v2[i]) if i < len2 else 0

            if val1 < val2: return -1
            if val1 > val2: return 1
        return 0