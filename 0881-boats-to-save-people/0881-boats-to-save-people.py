# idea is to try to fit heavy one first, and then fit lightest one with that person if possible
class Solution:
    def numRescueBoats(self, people: List[int], limit: int) -> int:
        people.sort()
        boats, left, right = 0, 0, len(people)-1

        while left <= right:
            boats += 1
            if people[right] + people[left] <= limit: left += 1
            right -= 1
        return boats
