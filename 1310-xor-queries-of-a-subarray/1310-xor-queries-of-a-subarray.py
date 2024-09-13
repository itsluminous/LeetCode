class Solution:
    def xorQueries(self, arr: List[int], queries: List[List[int]]) -> List[int]:
        n, q = len(arr), len(queries)
        prefixXor, answer = [0] * n, [0] * q
        
        prefixXor[0] = arr[0]
        for i in range(1, n):
            prefixXor[i] = prefixXor[i-1] ^  arr[i]
        
        for i, query in enumerate(queries):
            start, end = query
            if start == 0:
                answer[i] = prefixXor[end]
            else:
                answer[i] = prefixXor[end] ^ prefixXor[start-1]
        return answer