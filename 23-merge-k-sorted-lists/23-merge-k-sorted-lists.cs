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
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        var n = lists.Length;
        if(n == 0) return null;
        
        var queue = new Queue<ListNode>();
        foreach(var lst in lists) queue.Enqueue(lst);
        
        while(queue.Count > 0){
            var len = queue.Count;
            if(len == 1) break; // we cannot merge further
            for(var i=0; i+1<len; i+=2){
                var lst1 = queue.Dequeue();
                var lst2 = queue.Dequeue();
                queue.Enqueue(Merge2Lists(lst1, lst2));
            }
        }
        
        return queue.Dequeue();
    }
    
    private ListNode Merge2Lists(ListNode list1, ListNode list2){
        var start = new ListNode();
        var curr = start;
        ListNode l1=list1, l2=list2;
        
        while(l1 != null || l2 != null){
            if(l1 == null){
                curr.next = l2;
                l2 = l2.next;
            }
            else if(l2 == null){
                curr.next = l1;
                l1 = l1.next;
            }
            else if(l1.val < l2.val){
                curr.next = l1;
                l1 = l1.next;
            }
            else{
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        
        return start.next;
    }
}