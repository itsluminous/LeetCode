class Solution:
    def maxTargetNodes(self, edges1: List[List[int]], edges2: List[List[int]]) -> List[int]:
        # nodes at even level will be colored 0, and odd level colored 1
        n, m = len(edges1) + 1, len(edges2) + 1
        color1 = [0] * n
        color2 = [0] * m

        # find max reachable nodes in tree1 & tree2 for each color
        depth1 = self.getDepth(edges1, color1)
        depth2 = self.getDepth(edges2, color2)
        maxDepth2 = max(depth2[0], depth2[1])  # max of odd or even level

        # find out max depth reachable in tree1 after joining with tree2
        ans = [0] * n
        for i in range(n):
            c = color1[i]
            ans[i] = depth1[c] + maxDepth2

        return ans

    def getDepth(self, edges: List[List[int]], color: List[int]) -> List[int]:
        n = len(edges) + 1

        # build tree
        tree = [[] for _ in range(n)]
        for u, v in edges:
            tree[u].append(v)
            tree[v].append(u)

        # find max even & odd depth
        depth = self.dfs(tree, color, -1, 0, 0)
        return [depth, n - depth]

    # find depth from each node
    def dfs(self, tree: List[List[int]], color: List[int], parent: int, node: int, depth: int) -> int:
        count = 1 - (depth % 2)
        color[node] = depth % 2  # color 0 = even, 1 = odd
        for next_node in tree[node]:
            if next_node == parent: continue
            count += self.dfs(tree, color, node, next_node, depth + 1)

        return count
