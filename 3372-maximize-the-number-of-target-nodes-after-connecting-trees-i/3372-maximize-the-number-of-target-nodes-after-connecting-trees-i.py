class Solution:
    def maxTargetNodes(self, edges1: List[List[int]], edges2: List[List[int]], k: int) -> List[int]:
        # find max reachable nodes in tree1 & tree2 for each starting node
        depth1 = self.get_depth(edges1, k)
        depth2 = self.get_depth(edges2, k - 1)

        max_depth2 = max(depth2)
        for i in range(len(depth1)):
            depth1[i] += max_depth2

        return depth1

    def get_depth(self, edges, k):
        n = len(edges) + 1

        # build tree
        tree = [[] for _ in range(n)]
        for u, v in edges:
            tree[u].append(v)
            tree[v].append(u)

        # find depth from each node
        depth = [0] * n
        for i in range(n):
            depth[i] = self.dfs(tree, k, i, -1)

        return depth

    # find depth from each node
    def dfs(self, tree, k, node, parent):
        if k < 0: return 0
        count = 1  # self
        for nextt in tree[node]:
            if nextt == parent: continue
            count += self.dfs(tree, k - 1, nextt, node)
        return count