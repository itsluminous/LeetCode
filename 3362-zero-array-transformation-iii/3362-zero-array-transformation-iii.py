# idea is to pick queries with longest range, as they will help in reducing more indexes
class Solution:
    def maxRemoval(self, nums: List[int], queries: List[List[int]]) -> int:
        nLen, qLen = len(nums), len(queries)
        queries.sort(key=lambda x: x[0])    # sort queries by starting idx
        pq = []     # maxHeap to get longest end index first
        delta = [0] * (nLen + 1)   # at what index we can decrement, and how much

        decr = q = 0   # how many decrements can we do at this point
        for i, num in enumerate(nums):
            decr += delta[i]
            
            # put all queries starting at curr index in heap
            while q < qLen and queries[q][0] == i:
                heappush(pq, -queries[q][1])
                q += 1
            
            # use queries in heap till the curr index can be made 0
            while decr < num and pq and -pq[0] >= i:
                decr += 1
                delta[-heappop(pq) + 1] -= 1

            # check if num can be made 0
            if decr < num: return -1

        return len(pq)   # all leftovers in heap can be removed