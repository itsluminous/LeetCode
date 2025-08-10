class Solution:
    def numOfUnplacedFruits(self, fruits: List[int], baskets: List[int]) -> int:
        n, match = len(baskets), 0
        for fruit in fruits:
            for i in range(n):
                if fruit <= baskets[i]:
                    baskets[i] = 0
                    match += 1
                    break

        return len(fruits) - match