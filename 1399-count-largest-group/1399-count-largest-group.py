class Solution:
    def countLargestGroup(self, n: int) -> int:
        max_size = 0
        count_map = defaultdict(int)

        for num in range(1, n + 1):
            digit_sum = self.get_digit_sum(num)
            count_map[digit_sum] += 1
            max_size = max(max_size, count_map[digit_sum])

        return sum(1 for size in count_map.values() if size == max_size)

    def get_digit_sum(self, num: int) -> int:
        digit_sum = 0
        while num > 0:
            digit_sum += num % 10
            num //= 10
        return digit_sum