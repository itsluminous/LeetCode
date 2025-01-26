class Solution:
    def maximumInvitations(self, favorite: List[int]) -> int:
        n = len(favorite)

        # count how many fans each person has
        fans = [0] * n
        for person in favorite: fans[person] += 1

        # then topological sort the dependency graph
        # we start with people who have no fans, as they will be at the edges
        queue = deque()
        for person in range(n):
            if fans[person] == 0:
                queue.append(person)
        
        # find out longest path leading to each person
        depth = [1] * n
        while queue:
            person = queue.popleft()
            fav = favorite[person]
            depth[fav] = max(depth[fav], 1 + depth[person])
            fans[fav] -= 1
            if fans[fav] == 0: queue.append(fav)

        # there can be 2 cases for max invitation
        # 1. there is a very big cycle where first person is a favourite of last person
        # 2. there is a cycle of 2 nodes (who like each other), and they each have a tail of fans
        longestCycle = twoCycleChain = 0

        # detect cycle
        for person in range(n):
            if fans[person] == 0: continue # what a miserable life! (or we already visited this one)

            cycleLength, curr = 0, person
            while fans[curr] != 0:
                fans[curr] = 0 # mark as visited
                curr = favorite[curr]
                cycleLength += 1

            if cycleLength == 2:    # case 2 (two people like each other)
                twoCycleChain += depth[person] + depth[favorite[person]]
            else:                   # case 1 (a complete cycle of people)
                longestCycle = max(longestCycle, cycleLength)

        return max(longestCycle, twoCycleChain)