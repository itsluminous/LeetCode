class Solution:
    def arrayRankTransform(self, arr: List[int]) -> List[int]:
        n = len(arr)
        if n == 0: return []

        # clone the array and sort it
        sorted_arr = sorted(arr)

        # assign rank to each number
        rank = {}
        rank[sorted_arr[0]] = 1
        curr = 2
        for i in range(1, n):
            if sorted_arr[i] == sorted_arr[i-1]: continue
            rank[sorted_arr[i]] = curr
            curr += 1

        # build the final output
        for i, num in enumerate(arr):
            arr[i] = rank[num]
        
        return arr