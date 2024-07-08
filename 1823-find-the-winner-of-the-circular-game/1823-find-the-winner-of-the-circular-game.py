class Solution:
    def findTheWinner(self, n: int, k: int) -> int:
        idx = 0         # for only 1 person, ans is person at idx 0 (i.e. person 1)
        for i in range(2, n+1):
            idx = (idx + k) % i    # ans if there are "i" people in circle
        return idx + 1  # person at idx 0 is person 1, similarly for other idx