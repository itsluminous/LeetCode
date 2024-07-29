# for each number in array, count how many on left are smaller & how many on right are greater
# do opposite for descending sequence
class Solution:
    def numTeams(self, rating: List[int]) -> int:
        count, n = 0, len(rating)

        for i in range(1, n-1):
            smaller, greater = [0, 0], [0, 0]
            for j in range(n):
                if i == j: continue
                if rating[i] < rating[j]:
                    if j > i: smaller[1] += 1
                    else: smaller[0] += 1
                else:
                    if j > i: greater[1] += 1
                    else: greater[0] += 1

            count += (smaller[0] * greater[1]) + (greater[0] * smaller[1])
        return count