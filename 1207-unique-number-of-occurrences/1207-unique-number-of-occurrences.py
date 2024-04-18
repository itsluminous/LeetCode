class Solution:
    def uniqueOccurrences(self, arr: List[int]) -> bool:
        freq = Counter(arr)
        allFreq = freq.values()
        distinct = set(allFreq)

        return len(allFreq) == len(distinct)