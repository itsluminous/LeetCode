class Solution:
    def minimumAbsDifference(self, arr: List[int]) -> List[List[int]]:
        arr.sort()
        ans = []
        diff = arr[-1] - arr[0]

        for i in range(1, len(arr)):
            if arr[i] - arr[i-1] < diff:
                diff = arr[i] - arr[i-1]
                ans = []
            if arr[i] - arr[i-1] == diff:
                ans.append([arr[i-1], arr[i]])

        return ans