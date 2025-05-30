class Solution:
    def closestMeetingNode(self, edges: List[int], node1: int, node2: int) -> int:
        n = len(edges)
        dist1 = [-1] * n
        dist2 = [-1] * n

        # find out center node's distance
        curr_dist = 0
        min_dist, min_node = float('inf'), -1
        while node1 != -1 or node2 != -1:
            # check if already visited
            visited = True
            if node1 != -1 and dist1[node1] == -1: visited = False
            if node2 != -1 and dist2[node2] == -1: visited = False
            if visited: break

            if node1 != -1: dist1[node1] = curr_dist
            if node2 != -1: dist2[node2] = curr_dist

            if node1 != -1 and dist2[node1] != -1 and min_dist >= max(dist2[node1], dist1[node1]):
                new_dist = max(dist2[node1], dist1[node1])
                if new_dist == min_dist: min_node = min(min_node, node1)
                else: min_node = node1
                min_dist = new_dist

            if node2 != -1 and dist1[node2] != -1 and min_dist >= max(dist1[node2], dist2[node2]):
                new_dist = max(dist1[node2], dist2[node2])
                if new_dist == min_dist: min_node = min(min_node, node2)
                else: min_node = node2
                min_dist = new_dist

            if min_node != -1: return min_node

            # prepare for next iteration
            curr_dist += 1
            if node1 != -1: node1 = edges[node1]
            if node2 != -1: node2 = edges[node2]

        return -1