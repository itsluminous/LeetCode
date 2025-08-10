class Solution:
    def totalFruit(self, fruits: List[int]) -> int:
        uniq = defaultdict(int)
        n, ans, left = len(fruits), 1, 0

        for right in range(n):
            uniq[fruits[right]] += 1
            while len(uniq) > 2:
                uniq[fruits[left]] -= 1
                if uniq[fruits[left]] == 0:
                    del uniq[fruits[left]]
                left += 1
            ans = max(ans, right - left + 1)

        return ans