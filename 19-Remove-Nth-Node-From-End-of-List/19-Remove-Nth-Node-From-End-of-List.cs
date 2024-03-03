public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode parent = null, remove = head, tail = head;
        int gap = 0;
        do{
            if(gap == n){
                parent = remove;
                remove = remove.next;
            }
            else gap++;
            tail = tail.next;
        }while(tail != null);

        if(parent == null) return head.next;
        parent.next = remove.next;
        return head;
    }
}

// This is also accepted
public class SolutionAccepted {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var fast = head;
        var slow = head;
        var i=0;
        for(; i<n && fast.next != null; i++) fast = fast.next;
        
        if(i!= n){
            head = head.next;
            return head;
        }
        
        while(fast.next != null){
            slow = slow.next;
            fast = fast.next;
        }
        
        slow.next = slow.next.next;
        return head;
    }
}