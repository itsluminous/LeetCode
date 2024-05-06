// Recursive
public class Solution {
    public ListNode RemoveNodes(ListNode head) {
        if(head == null) return head;
        head.next = RemoveNodes(head.next);
        if(head.next != null && head.val < head.next.val) return head.next;
        return head;
    }
}

// Accepted - Iterative
public class SolutionIterative {
    public ListNode RemoveNodes(ListNode head) {
        var stack = new Stack<(ListNode node, ListNode parent)>();    // the node and it's parent
        ListNode newhead = new ListNode(-1, head);
        var parent = newhead;
        
        var curr = parent.next;
        do{
            stack.Push((curr, parent));
            parent = curr;
            curr = curr.next;
        } while(curr != null);

        var biggest = stack.Pop().node.val;
        while(stack.Count > 0){
            var (node, prnt) = stack.Pop();
            if(node.val >= biggest) biggest = node.val;
            else prnt.next = node.next;
        }

        return newhead.next;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */