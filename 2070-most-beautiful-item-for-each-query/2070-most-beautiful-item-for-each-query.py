class Solution:
    def maximumBeauty(self, items: List[List[int]], queries: List[int]) -> List[int]:
        # sort by price
        items.sort(key=lambda item: item[0])
        n = len(items)

        # find max beauty for each index
        beauty = [0]*n
        beauty[0] = items[0][1]
        for i in range(1, n):
            beauty[i] = max(beauty[i-1], items[i][1])

        # evaluate the query
        # find the appropriate index in items arr using binary search
        # then find the corresponding max beauty value in beauty array
        for i in range(len(queries)):
            # if the query is lower than lowest price, then ans will be 0
            if items[0][0] > queries[i]:
                queries[i] = 0
                continue

            # binary search
            low, high = 0, n-1
            while low <= high:
                mid = low + (high-low)//2
                if items[mid][0] > queries[i]: high = mid-1
                else: low = mid+1
            queries[i] = beauty[low-1]

        return queries