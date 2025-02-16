class Solution:
    def maxWeight(self, pizzas: List[int]) -> int:
        pizzas.sort()

        days = len(pizzas) // 4
        even = days // 2
        odd = days - even
        weight = 0

        # pick heaviest pizzas on odd days
        idx = len(pizzas) - 1
        for _ in range(odd):
            weight += pizzas[idx]
            idx -= 1

        # pick second heaviest pizzas on even days
        idx -= 1
        for _ in range(even):
            weight += pizzas[idx]
            idx -= 2

        return weight