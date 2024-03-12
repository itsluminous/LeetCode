// intuition is that prefixSum at index i1 & i2 will be same if all indexes between i1 & i2 sum up to 0
// if we find such case, then we simply adjust the next pointer of linked list to discard these middle nodes

public class Solution {
    public ListNode RemoveZeroSumSublists(ListNode head) {
        var dict = new Dictionary<int, ListNode>();     // store parent for each prefixSum
        var first = new ListNode(-1, head);
        dict[0] = first;
        
        var prefixSum = 0;
        var curr = first.next;  // head node
        while(curr != null){
            // special case - when number is zero
            if(curr.val == 0){
                dict[prefixSum].next = curr.next;
                curr = curr.next;
                continue;
            }

            prefixSum += curr.val;
            if(dict.ContainsKey(prefixSum)){
                var remove = dict[prefixSum].next;
                var ps = prefixSum + remove.val;    // prefix sum of node that will be deleted
                do{
                    dict.Remove(ps);
                    remove = remove.next;
                    if(remove != null)
                        ps += remove.val;
                }while(ps != prefixSum);
                dict[prefixSum].next = curr.next;
            }
            else
                dict[prefixSum] = curr;

            curr = curr.next;
        }   

        return first.next;
    }
}