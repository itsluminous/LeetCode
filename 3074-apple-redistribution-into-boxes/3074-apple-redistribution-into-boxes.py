class Solution:
    def minimumBoxes(self, apple: List[int], capacity: List[int]) -> int:
        total = sum(apple)
        capacity.sort(reverse=True)

        count = 0
        while total > 0:
            total -= capacity[count]
            count += 1
        return count