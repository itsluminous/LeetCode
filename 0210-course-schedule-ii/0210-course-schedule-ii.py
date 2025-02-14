class Solution:
    def findOrder(self, numCourses: int, prerequisites: List[List[int]]) -> List[int]:
        self.dependencies = [0] * numCourses
        adjList = self.makeGraph(numCourses, prerequisites)

        # start with courses which have dependencies == 0, i.e. not dependent on anyone
        queue = deque()
        for i in range(numCourses):
            if self.dependencies[i] == 0:
                queue.append(i)
        
        # BFS to start covering each available course one by one
        order = [0] * numCourses
        idx = 0
        while queue:
            curr = queue.popleft()
            order[idx] = curr
            idx += 1

            # each dependent of this course has one dependency satisfied
            # if all dependencies for a course is satisfied, then we add that in queue
            for next in adjList[curr]:
                self.dependencies[next] -= 1
                if self.dependencies[next] == 0:
                    queue.append(next)
        
        return order if idx == numCourses else []

    def makeGraph(self, numCourses: int, prerequisites: List[List[int]]) -> List[List[int]]:
        adjList = [[] for _ in range(numCourses)]

        for after, before in prerequisites:
            adjList[before].append(after)
            self.dependencies[after] += 1
        
        return adjList