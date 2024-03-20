class Solution {
    public ListNode mergeInBetween(ListNode list1, int a, int b, ListNode list2) {
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
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */