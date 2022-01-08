// reservoir sampling, without extra space
public class Solution {
    ListNode head;
    Random rand;
    
    public Solution(ListNode head) {
        this.head = head;
        rand = new Random();
    }
    
    public int GetRandom() {
        ListNode curr = head, result = head;
        
        for(var count=1; curr != null; count++){
            if (rand.Next(count) == 0) result = curr;
            curr = curr.next;
        }
        
        return result.val;
    }
}

// with o(n) extra space
public class Solution1 {
    int[] arr;
    Random rand;
    
    public Solution1(ListNode head) {
        var lst = new List<int>();
        while(head != null){
            lst.Add(head.val);
            head = head.next;
        }
        arr = lst.ToArray();
        rand = new Random();
    }
    
    public int GetRandom() {
        var idx = rand.Next(0,arr.Length);
        return arr[idx];
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

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */