func deleteNode(node *ListNode) {
    temp := node.Next
    node.Val = temp.Val
    node.Next = temp.Next
    temp = nil
}

/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */