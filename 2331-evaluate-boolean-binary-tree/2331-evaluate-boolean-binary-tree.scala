/**
 * Definition for a binary tree node.
 * class TreeNode(_value: Int = 0, _left: TreeNode = null, _right: TreeNode = null) {
 *   var value: Int = _value
 *   var left: TreeNode = _left
 *   var right: TreeNode = _right
 * }
 */
object Solution {
    def evaluateTree(root: TreeNode): Boolean = {
        // since it is a full binary tree, then if any child is null, then it is a leaf node
        if(root.left == null) root.value == 1
        else {
            val leftVal = evaluateTree(root.left)
            val rightVal = evaluateTree(root.right)

            if (root.value == 2) leftVal || rightVal
            else leftVal && rightVal
        }
    }
}