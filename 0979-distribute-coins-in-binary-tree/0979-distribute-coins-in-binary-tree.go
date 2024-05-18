var moves int

func distributeCoins(root *TreeNode) int {
    moves = 0
    dfs(root)
    return moves
}

// return -ve if node is accepting and +ve if it is giving back
func dfs(root *TreeNode) int {
    if root == nil {
        return 0
    }

    leftBalance := dfs(root.Left)
    rightBalance := dfs(root.Right)

    curr := leftBalance + rightBalance + root.Val - 1
    moves += int(math.Abs(float64(curr)))
    return curr
}

/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */