class Solution:
    def addOneRow(self, root: Optional[TreeNode], val: int, depth: int) -> Optional[TreeNode]:
        new_root = TreeNode(0, root)
        curr_depth = 0
        queue = deque()

        queue.append(new_root)
        while queue:
            curr_depth += 1
            count = len(queue)
            
            for i in range(count):
                node = queue.popleft()
                if depth == curr_depth:
                    node.left = TreeNode(val, node.left, None)
                    node.right = TreeNode(val, None, node.right)
                else:
                    if node.left != None: queue.append(node.left)
                    if node.right != None: queue.append(node.right)

        return new_root.left