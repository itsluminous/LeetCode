class Solution:
    def maxAverageRatio(self, classes: List[List[int]], extraStudents: int) -> float:
        # sort classes by gain desc, i.e. the class which sees max benefit on adding a student
        maxHeap = []
        for classs in classes:
            passed, total = classs[0], classs[1]
            g = self.gain(passed, total)
            heapq.heappush(maxHeap, (-g, passed, total))

        # add extra students to classes where max gain is seen
        while extraStudents > 0:
            extraStudents -= 1
            _, passed, total = heapq.heappop(maxHeap)
            passed, total = passed+1, total+1   # +1 because we add extra student
            heapq.heappush(maxHeap, (-self.gain(passed, total), passed, total))

        # calculate final avg
        allTotal = 0
        while maxHeap:
            _, passed, total = heapq.heappop(maxHeap)
            allTotal += (passed / total)

        return allTotal / len(classes)

    def gain(self, passed: int, total: int) -> int:
        return (passed + 1) / (total + 1) - passed / total