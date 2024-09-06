func modifiedList(nums []int, head *ListNode) *ListNode {
    uniq := make(map[int]bool)
    for _, num := range nums {
        uniq[num] = true
    }

    newHead := &ListNode{-1, head}
    curr := newHead

    for curr.Next != nil {
        if uniq[curr.Next.Val] {
            curr.Next = curr.Next.Next
        } else {
            curr = curr.Next
        }
    }
    return newHead.Next
}

/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */