# any node which is below the node "1" or in any adjacent path of node "1" will have missing as "1"
# for other nodes, calculate missing for node "1", then go upwards till root node
class Solution:
    def smallestMissingValueSubtree(self, parents: List[int], nums: List[int]) -> List[int]:
        n = len(parents)
        self.tree = [[] for _ in range(n)]
        self.visited = set()

        # build the tree (adj list)
        for i in range(1, n):
            p = parents[i]
            self.tree[p].append(i)

        # by default, assume "1" to be missing number for all
        ans = [1] * n

        # find out the node with value 1.
        # We have to evaluate missing for any node upwards from this node
        # for other nodes, missing value has to be 1
        one_idx = -1
        for i in range(n):
            if nums[i] == 1:
                one_idx = i
                break

        # if there is no node with value 1, then all will have 1 as missing value
        if one_idx == -1: return ans

        missing = 1
        curr, prev = one_idx, -1;   # track prev so that we don't process a subtree if already processed
        while curr != -1:
            # visit this subtree
            for child in self.tree[curr]:
                if child == prev: continue
                self.dfs(child, nums)

            self.visited.add(nums[curr])
            
            # find missing value
            while missing in self.visited: missing += 1
            ans[curr] = missing

            # travel upwards in tree
            prev, curr = curr, parents[curr]

        return ans

    # visit entire subtree starting from 'node' and mark corresponding genetic value as visited
    def dfs(self, node, nums):
        self.visited.add(nums[node])
        for child in self.tree[node]:
            self.dfs(child, nums)