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

// using stack to store nodes as we traverse
public class Solution {
    public ListNode ReverseEvenLengthGroups(ListNode head) {
        var maxNodesInGroup = 1;   // first group will have 1 nodes
        var curr = head;
        while(curr != null){
            var count = 0;
            var start = curr;
            var stack = new Stack<int>();   // we store values, not nodes in stack
            
            // store all nodes in stack as we traverse, so that popping reverses it
            while(count != maxNodesInGroup && curr != null){
                stack.Push(curr.val);
                curr = curr.next;
                count++;
            }
            
            // if there are even nodes in group, reverse it
            if(count % 2 == 0){
                while(start != curr){
                    start.val = stack.Pop();
                    start = start.next;
                }
            }
            
            maxNodesInGroup++;
        }
        return head;
    }
}


// Accepted
public class Solution1 {
    public ListNode ReverseEvenLengthGroups(ListNode head) {
        var nodesInGroup = 1;   // first group will have 1 nodes
        ListNode curr = head, prev = null, oddPrev = null;
        while(curr != null){
            if(nodesInGroup%2 != 0){
                oddPrev = prev;
                int count;
                for(count=0; count<nodesInGroup && curr != null; count++){
                    prev = curr;
                    curr = curr.next; 
                }
                // if last group was supposed to be odd but it was even
                if(curr == null && count!=nodesInGroup && count%2 == 0)
                    oddPrev.next = ReverseLinkedList(oddPrev.next, count);
            }
            else{
                var len = FragmentLength(curr, nodesInGroup);
                if(len%2 != 0) break;   // if count is odd, then we don't reverse it
                var last = ReverseLinkedList(curr, len);
                prev.next = last;
                prev = curr;
                curr = curr.next;
            }  
            
            nodesInGroup++;
        }
        
        return head;
    }
    
    private ListNode ReverseLinkedList(ListNode start, int count){
        var i = 1;
        var node1 = start;
        var temp = node1.next;
        while(node1.next != null && i++ < count){
            var node2 = temp;
            temp = node2.next;
            node2.next = node1;
            node1 = node2;
        }
        start.next = temp;
        return node1;
    }
    
    private int FragmentLength(ListNode start, int count){
        var temp = start;
        int i=0;
        while(temp != null && i<count){
            i++;
            temp = temp.next;
        }
        return i;
    }
}