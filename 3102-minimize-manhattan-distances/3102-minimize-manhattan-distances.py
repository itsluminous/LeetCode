class Solution:
    def minimumDistance(self, points: List[List[int]]) -> int:
        n = len(points)
        minimumVal = float('inf')

        plus = []
        minus = []

        # for each point, store (x+y) and (x-y)
        for i,point in enumerate(points):
            plus.append(ValueIndex(point[0] + point[1], i))
            minus.append(ValueIndex(point[0] - point[1], i))

        plus.sort(key=lambda x: x.val)
        minus.sort(key=lambda x: x.val)

        # now one by one remove each point and compute answer
        for i in range(n):
            # now we need to find the extreme values from points array after removing point i
            maxPlus = plus[-2].val if plus[-1].idx == i else plus[-1].val
            minPlus = plus[1].val if plus[0].idx == i else plus[0].val
            maxMinus = minus[-2].val if minus[-1].idx == i else minus[-1].val
            minMinus = minus[1].val if minus[0].idx == i else minus[0].val

            # maximum manhattan distance after removing point i
            maxAfterRemovingOne = max(maxPlus - minPlus, maxMinus - minMinus)

            # update final answer
            minimumVal = min(minimumVal, maxAfterRemovingOne)

        return minimumVal


class ValueIndex:
    def __init__(self, v, i):
        self.val = v
        self.idx = i
