class Solution:
    def postorder(self, root: 'Node') -> List[int]:
        def traverse(root: 'Node'):
            if not root: return
            for child in root.children:
                traverse(child)
            ans.append(root.val)
        
        ans = []
        traverse(root)
        return ans


"""
# Definition for a Node.
class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children = children
"""