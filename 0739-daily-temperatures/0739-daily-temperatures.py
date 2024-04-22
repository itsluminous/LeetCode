class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        n = len(temperatures)
        wait = [0]*n
        wait[n-1] = 0

        for i in range(n-2, -1, -1):
            idx = i+1
            while idx < n:
                # found a temperatures greater than current
                if temperatures[idx] > temperatures[i]:
                    wait[i] = idx-i
                    break
                # case where bigger temperatures does not exist
                if wait[idx] == 0:
                    idx = n
                    break
                # find next bigger temperatures
                idx += wait[idx]
            if idx == n: wait[i] = 0

        return wait