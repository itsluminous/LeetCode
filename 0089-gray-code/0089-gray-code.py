# INTUITION
# If n = 0 => {0}
# If n = 1 => {0,1} {0 , 0 + pow(2,0)}
# If n = 2 => {0,1,3,2} {0 , 1 , 1 + pow(2,1) , 0 + pow(2,1)}
# If n = 3 => {0,1,3,2,6,7,5,4} {0 , 1 , 3 , 2 , 2 + pow(2,2) , 3 + pow(2,2) , 1 + pow(2,2) , 0 + pow(2,2)}

class Solution:
    def grayCode(self, n: int) -> List[int]:
        totlen = pow(2, n)
        ans = [0]

        pwr = 0
        while len(ans) < totlen:
            for i in range(len(ans)-1, -1, -1):
                ans += [ans[i] + pow(2, pwr)]
            pwr += 1

        return ans