class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        Queue<ListNode> queue = new LinkedList<>();
        for(var list : lists)
            queue.offer(list);
        
        while(queue.size() > 1){
            var list1 = queue.poll();
            var list2 = queue.poll();
            queue.offer(mergeTwoLists(list1, list2));
        }

        return queue.poll();
    }

    private ListNode mergeTwoLists(ListNode list1, ListNode list2) {
        var newHead = new ListNode(-1);
        var curr = newHead;
        
        while(list1 != null && list2 != null){
            if(list1.val < list2.val){
                curr.next = list1;
                list1 = list1.next;
            }
            else{
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;
        }

        if(list1 != null) curr.next = list1;
        if(list2 != null) curr.next = list2;

        return newHead.next;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */