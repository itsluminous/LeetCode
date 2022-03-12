/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        // Make copy of all nodes - in place
        for(var itr = head; itr!= null; itr = itr.next.next){
            var node = new Node(itr.val);
            node.next = itr.next;
            itr.next = node;
        }
        
        // Assign random pointers for the copy nodes.
        for(var itr = head; itr!= null; itr = itr.next.next){
            if(itr.random != null){
                itr.next.random = itr.random.next;
            }
        }
        
        // Split original and copy list
        Node head2 = new Node(0), tail = head2;
        for(var itr = head; itr!= null; itr = itr.next, tail = tail.next){
            tail.next = itr.next;
            itr.next = itr.next.next;
        }
        
        return head2.next;
    }
}

// It would have worked if all nodes had unique values
public class Solution1 {
    public Node CopyRandomList(Node head) {
        var pending = new Dictionary<int,List<Node>>();
        var added = new Dictionary<int, Node>();
        Node head2 = new Node(0), tail = head2;
        
        while(head != null){
            var curr = new Node(head.val);
            added[head.val] = curr;
            // if random node of curr exists, link it, else add to pending queue
            if(head.random != null && added.ContainsKey(head.random.val))
                curr.random = added[head.random.val];
            else if(head.random != null)
                if(pending.ContainsKey(head.random.val))
                    pending[head.random.val].Add(curr);
                else
                    pending[head.random.val] = new List<Node>{curr};
            
            // if someone is waiting for curr node in pending queue, link them
            if(pending.ContainsKey(curr.val)){
                foreach(var pendingNode in pending[curr.val])
                    pendingNode.random = curr;
                pending.Remove(curr.val);
            }
            
            // prepare for next iteration
            head = head.next;
            tail.next = curr;
            tail = curr;
        }
        
        return head2.next;
    }
}