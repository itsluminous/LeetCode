func evaluateTree(root *TreeNode) bool {
    // since it is a full binary tree, then if any child is null, then it is a leaf node
    if root.Left == nil {
        return root.Val == 1
    }
    
    leftVal := evaluateTree(root.Left)
    rightVal := evaluateTree(root.Right)

    if root.Val == 2 {
        return (leftVal || rightVal)
    }
    return (leftVal && rightVal)
}

/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */