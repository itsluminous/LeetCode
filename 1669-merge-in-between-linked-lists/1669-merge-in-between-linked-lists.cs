public class Solution {
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        var list2Last = list2;
        while(list2Last.next != null) 
            list2Last = list2Last.next;

        var pos = 0;
        var start = new ListNode(0, list1);
        var list1cur = start;
        do{
            var next = list1cur.next;
            if(pos == a)
                list1cur.next = list2;
            if(pos == b+1){
                list2Last.next = next;
                break;
            }
            list1cur = next;
            pos++;
        }while(list1cur!=null);

        return start.next;
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