public class Solution {
    public ListNode ModifiedList(int[] nums, ListNode head) {
        var set = new HashSet<int>();
        foreach(var num in nums)
            set.Add(num);

        var newHead = new ListNode(-1, head);
        var curr = newHead;;
        while(curr.next != null){
            if(set.Contains(curr.next.val)){
                curr.next = curr.next.next;
            }
            else{
                curr = curr.next;
            }
        }
        return newHead.next;
    }
}