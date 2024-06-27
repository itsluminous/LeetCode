# the center node is only node which has more than one edge
class Solution:
    def findCenter(self, edges: List[List[int]]) -> int:
        first, second = edges[0], edges[1]
        if first[0] == second[0] or first[0] == second[1]: return first[0]
        return first[1]